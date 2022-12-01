using System.ComponentModel;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos
{
    public enum TipoDeProduto
    {
        [Description("Produto")] Produto = 0,
        [Description("Balança")] Balanca = 1,
        [Description("Grade")] Grade = 2,
        [Description("Combustível")] Combustivel = 3,
        [Description("Medicamento")] Medicamento = 4,
    }
}