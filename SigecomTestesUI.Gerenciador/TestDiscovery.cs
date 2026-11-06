using System.Reflection;

namespace SigecomTestesUI.Gerenciador;

/// <summary>Lê os testes direto do assembly compilado, sem executar nada (MetadataLoadContext).</summary>
public static class TestDiscovery
{
    public static List<TestInfo> Discover(string assemblyPath)
    {
        var dir = Path.GetDirectoryName(assemblyPath)!;
        var paths = Directory.GetFiles(dir, "*.dll")
            .Concat(Directory.GetFiles(FrameworkDir(), "*.dll"))
            .GroupBy(Path.GetFileName)
            .Select(g => g.First());

        using var mlc = new MetadataLoadContext(new PathAssemblyResolver(paths));
        var assembly = mlc.LoadFromAssemblyPath(assemblyPath);

        var result = new List<TestInfo>();
        foreach (var type in SafeGetTypes(assembly).Where(t => t.IsClass && !t.IsAbstract && t.IsPublic))
        {
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                var test = method.GetCustomAttributesData()
                    .FirstOrDefault(a => a.AttributeType.FullName == "NUnit.Framework.TestAttribute");
                if (test == null) continue;

                var description = test.NamedArguments
                    .FirstOrDefault(n => n.MemberName == "Description").TypedValue.Value as string;

                result.Add(new TestInfo
                {
                    Namespace = type.Namespace ?? "",
                    Class = type.Name,
                    Method = method.Name,
                    Description = description
                });
            }
        }

        return result.OrderBy(t => t.Namespace).ThenBy(t => t.Class).ThenBy(t => t.Method).ToList();
    }

    /// <summary>
    /// Pasta do runtime .NET instalado na máquina (preferindo o 3.1, alvo do projeto de testes). Não dá para usar o runtime
    /// do próprio gerenciador: no exe self-contained as DLLs do framework ficam embutidas e não existem soltas em disco.
    /// </summary>
    private static string FrameworkDir()
    {
        var dotnetExe = DotnetLocator.Path;
        var root = File.Exists(dotnetExe)
            ? Path.GetDirectoryName(dotnetExe)!
            : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "dotnet");
        var shared = Path.Combine(root, "shared", "Microsoft.NETCore.App");

        if (Directory.Exists(shared))
        {
            var versoes = Directory.GetDirectories(shared)
                .Select(d => (Dir: d, Ok: Version.TryParse(Path.GetFileName(d).Split('-')[0], out var v), V: v))
                .Where(x => x.Ok && File.Exists(Path.Combine(x.Dir, "System.Private.CoreLib.dll")))
                .OrderByDescending(x => x.V.Major == 3 && x.V.Minor == 1) // 3.1 primeiro
                .ThenByDescending(x => x.V)
                .ToList();
            if (versoes.Count > 0) return versoes[0].Dir;
        }

        var local = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
        if (File.Exists(Path.Combine(local, "System.Private.CoreLib.dll"))) return local;

        throw new InvalidOperationException(
            "Não encontrei o runtime do .NET instalado. Abra \"Requisitos…\" e instale o .NET Core 3.1 Runtime.");
    }

    private static IEnumerable<Type> SafeGetTypes(Assembly assembly)
    {
        try { return assembly.GetTypes(); }
        catch (ReflectionTypeLoadException ex) { return ex.Types.Where(t => t != null)!; }
    }
}
