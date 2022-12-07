using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using System;
using System.Linq;
using OpenQA.Selenium;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto
{
    public class PesquisaDeProdutoPage : PageObjectModel
    {
        public PesquisaDeProdutoPage(DriverService driver) : base(driver) { }

        public void PesquisarProdutoDoConfirmacaoDeItem(string nomeDoProduto)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PesquisaDeProdutoModel.ElementoParametroDePesquisa, nomeDoProduto, Keys.F5);
        }

        public void PesquisarProduto(string nomeDoProduto)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoId(PesquisaDeProdutoModel.ElementoParametroDePesquisa, nomeDoProduto);
        }

        public void PesquisarProdutoComEnter(string nomeDoProduto)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PesquisaDeProdutoModel.ElementoParametroDePesquisa, nomeDoProduto, Keys.Enter);
        }

        public bool VerificarSeExisteProdutoNaGrid(string nomeDoProduto)
        {
            var nomeDoProdutoNaGrid = DriverService.PegarValorDaColunaDaGrid("Nome");
            return nomeDoProduto.Equals(nomeDoProdutoNaGrid);
        }

        public bool VerificarSeCarregouOsDadosDoProduto() => 
            DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNomeProduto).Equals(PesquisaDeProdutoInformacoesParaTesteModel.NomeFinalDoProduto);

        public bool VerificarSeExisteQualquerProdutoNaGrid() => 
            DriverService.PegarValorDaColunaDaGrid("Nome").Any();

        public bool FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void PesquisarComF9UmProdutoNaTelaDeCadastroDeProduto(ILifetimeScope beginLifetimeScope, out CadastroDeProdutoPage.CadastroDeProdutoBasePage cadastroDeProdutoBasePage)
        {
            var resolveCadastroDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage.CadastroDeProdutoBasePage>>();
            cadastroDeProdutoBasePage = resolveCadastroDeProdutoPage(DriverService);
            PesquisarUmProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoBasePage);
        }

        public void PesquisarComF9UmProdutoNaTelaPrincipal(ILifetimeScope beginLifetimeScope)
        {
            var resolveCadastroDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage.CadastroDeProdutoBasePage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService);
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
        }

        private static void PesquisarUmProdutoNaTelaDeCadastroDeProduto(CadastroDeProdutoPage.CadastroDeProdutoBasePage cadastroDeProdutoBasePage)
        {
            cadastroDeProdutoBasePage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoBasePage.ClicarNaOpcaoDoSubMenu();
            cadastroDeProdutoBasePage.ClicarNoAtalhoDePesquisar();
        }

        public void FecharSomenteTelaDePesquisa() => 
            FecharJanelaComEsc();

        public void FecharTelasDeProduto(CadastroDeProdutoPage.CadastroDeProdutoBasePage cadastroDeProdutoBasePage)
        {
            FecharJanelaComEsc();
            cadastroDeProdutoBasePage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}
