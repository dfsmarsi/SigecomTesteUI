namespace SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces
{
    public interface IContaBasePage
    {
        void RealizarFluxoDeGerarContaAReceber(string valorDaConta, string numeroDocumento);
        void RealizarFluxoDeGerarContaAReceberComHaver(string valorDaConta, string numeroDocumento);
        void RealizarFluxoDeGerarContaAPagar(string valorDaConta);
    }
}
