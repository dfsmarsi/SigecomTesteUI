using System.ComponentModel;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Enum
{
    public enum FormaDePagamento
    {
        [Description("Dinheiro")] Dinheiro = 0,
        [Description("Dinheiro com troco")] DinheiroComTroco = 1,
        [Description("Crédito")]  Credito = 2,
        [Description("Prazo")] Prazo = 3,
        [Description("Cheque")] Cheque = 4,
        [Description("Banco")] Banco = 5,
        [Description("Boleto")] Boleto = 6,
        [Description("Pix")] Pix = 7
    }
}
