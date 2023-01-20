using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.OrdemDeServico.Page
{
    public class CadastrarObjetoPage: PageObjectModel
    {
        public CadastrarObjetoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastrarObjetoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastrarObjetoModel.BotaoSubMenu);

        public void RealizarFluxoDeCadastrarObjetoNaOrdemDeServico()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoName(CadastrarObjetoModel.BotaoDoCriarUmNovoObjeto);
            DriverService.DigitarNoCampoName(CadastrarObjetoModel.ElementoDoNomeDoObjeto, CadastrarObjetoModel.NomeDoObjeto);
            ClicarBotaoName(CadastrarObjetoModel.ElementoNameDoGravar);
        }

        private void FecharTelaDeControleDeObjetosComEsc() =>
            DriverService.FecharJanelaComEsc(CadastrarObjetoModel.ElementoTelaDeControleDeObjetos);
    }
}
