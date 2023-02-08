using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using SigecomTestesUI.Sigecom.Estoque.ManutencaoDeEstoque.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Estoque.AlteracaoEmMassa.Page
{
    public class AlteracaoEmMassaPrincipalPage: PageObjectModel
    {
        public AlteracaoEmMassaPrincipalPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ManutencaoDeEstoqueModel.BotaoMenuEstoque);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ManutencaoDeEstoqueModel.BotaoSubMenu);

        public void RealizarFluxoDaAlteracaoEmMassaNaManutencaoDeEstoque()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa,
                PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto, Keys.Enter);
            ClicarBotaoName(ManutencaoDeEstoqueModel.BotaoDeAlteracaoEmMassa);

            // Act
            

            // Assert
            
            FecharTelaDeAlteracaoEmMassaComEsc();
        }

        private void FecharTelaDeAlteracaoEmMassaComEsc() =>
            DriverService.FecharJanelaComEsc(ManutencaoDeEstoqueModel.ElementoTelaDeManutencaoDeEstoque);
    }
}
