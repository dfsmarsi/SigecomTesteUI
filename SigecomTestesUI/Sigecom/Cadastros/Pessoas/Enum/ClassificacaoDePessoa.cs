using System.ComponentModel;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Enum
{
    public enum ClassificacaoDePessoa
    {
        [Description("Física simples")] FisicaSimples = 0,
        [Description("Física completa")] FisicaCompleta = 1,
        [Description("Jurídica simples")] JuridicaSimples = 2,
        [Description("Jurídica completa")] JuridicaCompleta = 3
    }
}