using System;
using System.Text;

namespace SigecomTestesUI.ControleDeInjecao
{
    public class RegistrarDependenciaException : Exception
    {
        public RegistrarDependenciaException(string namespaceClasse, Exception innerException) :
            base(new StringBuilder($"Namespace da Classe de Injeção: {namespaceClasse}{Environment.NewLine}")
                .AppendLine(innerException.Message)
                .ToString(), innerException) { }
    }
}
