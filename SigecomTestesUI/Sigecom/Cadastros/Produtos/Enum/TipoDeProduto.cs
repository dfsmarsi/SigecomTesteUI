using System.ComponentModel;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Enum
{
    public enum TipoDeProduto
    {
        [Description("Simples")] Simples = 0,
        [Description("Balança")] Balanca = 1,
        [Description("Grade")] Grade = 2,
        [Description("Combustível")] Combustivel = 3,
        [Description("Medicamento")] Medicamento = 4,
        [Description("Serviço")] Servico = 5,
        [Description("Completo")] Completo = 6,
        [Description("Codigo de barras")] CodigoDeBarras = 7
    }
}