using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.BaseDasContas
{
    public class ContaBasePage:PageObjectModel, IContaBasePage
    {
        public ContaBasePage(DriverService driver) : base(driver)
        {
        }

        public void RealizarFluxoDeGerarContaAReceber(string valorDaConta) => 
            GerarContaAReceber(valorDaConta, "CONSUMIDOR");

        public void RealizarFluxoDeGerarContaAReceberComHaver(string valorDaConta) =>
            GerarContaAReceber(valorDaConta, "CONSUMIDOR COM HAVER");

        private void GerarContaAReceber(string valorDaConta, string cliente)
        {
            ClicarBotaoName(ContaAReceberModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePlanoConta,
                "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePessoa, cliente,
                Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDeHistorico, "", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeValor, valorDaConta);
            ClicarBotaoName(LancarContaAvulsaModel.Gravar);
        }

        public void RealizarFluxoDeGerarContaAPagar(string valorDaConta)
        {
            ClicarBotaoName(ContaAPagarModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePlanoConta, "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(LancarContaAvulsaModel.ElementoCampoDePessoa, "FORNECEDOR", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaModel.ElementoCampoDeHistorico, "", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaModel.ElementoCampoDeValor, valorDaConta);
            ClicarBotaoName(LancarContaAvulsaModel.Gravar);
        }
    }
}
