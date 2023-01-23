using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Model;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.LancarOrdemDeServico.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.ConsultaDeOrdemDeServico.Page
{
    public class FaturarNaConsultaDeOrdemDeServicoPage: PageObjectModel
    {
        public FaturarNaConsultaDeOrdemDeServicoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ConsultaDeOrdemDeServicoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeOrdemDeServicoModel.BotaoSubMenu);

        public void RealizarFluxoDeFaturarNaConsultaDaOrdemDeServico()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(ConsultaDeOrdemDeServicoModel.BotaoDeFaturarDaOrdemDeServico);
            DriverService.RealizarSelecaoDaFormaDePagamento(OrdemDeServicoModel.GridDeFormaDePagamento, 1);
            FecharTelaDeOrdemDeServicoComEsc();
        }

        private void FecharTelaDeOrdemDeServicoComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeOrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
    }
}
