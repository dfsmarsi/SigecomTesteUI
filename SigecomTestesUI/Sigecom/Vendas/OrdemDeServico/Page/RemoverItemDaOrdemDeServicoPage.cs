using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Page
{
    public class RemoverItemDaOrdemDeServicoPage: PageObjectModel
    {
        public RemoverItemDaOrdemDeServicoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(OrdemDeServicoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(OrdemDeServicoModel.BotaoSubMenu);

        public void RealizarFluxoDeRemoverItemNaOrdemDeServico()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            LancarProduto(LancarItensNaOrdemDeServicoModel.PesquisarItemId);
            ClicarBotaoName(OrdemDeServicoModel.CampoDaGridParaRemoverProduto);
            FecharTelaDeOrdemDeServicoComEsc();
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrdemDeServicoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void FecharTelaDeOrdemDeServicoComEsc() =>
            DriverService.FecharJanelaComEsc(OrdemDeServicoModel.ElementoTelaDeOrdemDeServico);
    }
}
