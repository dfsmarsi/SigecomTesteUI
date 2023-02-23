using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.ContaAReceber.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.BaseDasContas
{
    public class ContaBasePage:PageObjectModel, IContaBasePage
    {
        public ContaBasePage(DriverService driver) : base(driver)
        {
        }

        public void RealizarFluxoDeGerarContaAReceber()
        {
            ClicarBotaoName(ContaAReceberModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDePlanoConta, "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeCliente, "CARLOS ADAO DE MAGALHAES", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeHistorico, "", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeValor, "20,22");
            ClicarBotaoName(LancarContaAvulsaDaContaAReceberModel.Gravar);
        }

        public void RealizarFluxoDeGerarContaAPagar()
        {
            ClicarBotaoName(ContaAReceberModel.BotaoDeNovaConta);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDePlanoConta, "Acerto de caixa", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeCliente, "CARLOS ADAO DE MAGALHAES", Keys.Enter);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeHistorico, "", Keys.Enter);
            DriverService.EditarCampoComDuploCliqueNoBotaoId(LancarContaAvulsaDaContaAReceberModel.ElementoCampoDeValor, "20,22");
            ClicarBotaoName(LancarContaAvulsaDaContaAReceberModel.Gravar);
        }
    }
}
