using System.ComponentModel;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Enum
{
    public enum FormaDePagamento
    {
        [Description("Dinheiro")] Dinheiro = 0,
        [Description("Crédito")]  Credito = 1,
        [Description("Prazo")] Prazo = 2,
        [Description("Cheque")] Cheque = 3,
        [Description("Banco")] Banco = 4,
        [Description("Boleto")] Boleto = 5,
        [Description("Pix")] Pix = 6
    }
}
