using System.ComponentModel;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Enum
{
    public enum TipoDeClienteSimplificado
    {
        [Description("Físico com nome")] FisicoComNome = 0,
        [Description("Físico completo")] FisicoCompleto = 1,
        [Description("Físico com nome e cpf")] FisicoComNomeECpf = 2,
        [Description("Jurídico com nome")] JuridicoComNome = 3,
        [Description("Jurídico com nome e cnpj")] JuridicoComNomeECpf = 4
    }
}
