using System.ComponentModel;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Enum
{
    public enum TipoDeClienteSimplificado
    {
        [Description("Fisíco com nome")] FisicoNome = 0,
        [Description("Fisíco completo")] FisicoCompleto = 1,
        [Description("Fisíco com nome e cpf")] FisicoNomeCpf = 2,
        [Description("Jurídico com nome")] JuridicoNome = 3,
        [Description("Jurídico com nome e cnpj")] JuridicoNomeCnpj = 3,
    }
}
