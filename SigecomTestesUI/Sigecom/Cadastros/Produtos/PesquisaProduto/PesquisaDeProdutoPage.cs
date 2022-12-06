using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;
using System;
using System.Linq;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto
{
    public class PesquisaDeProdutoPage : PageObjectModel
    {
        public PesquisaDeProdutoPage(DriverService driver) : base(driver) { }

        public void PesquisarProduto(string nomeDoProduto)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoEnterId(PesquisaDeProdutoModel.ElementoParametroDePesquisa, nomeDoProduto);
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

        public void PesquisarComF9UmProdutoNaTelaDeCadastroDeProduto(ILifetimeScope beginLifetimeScope, out CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            var resolveCadastroDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage>>();
            cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService);
            PesquisarUmProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);
        }

        public void PesquisarComF9UmProdutoNaTelaPrincipal(ILifetimeScope beginLifetimeScope)
        {
            var resolveCadastroDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, CadastroDeProdutoPage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService);
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
        }

        private static void PesquisarUmProdutoNaTelaDeCadastroDeProduto(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            cadastroDeProdutoPage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisar();
        }

        public void FecharSomenteTelaDePesquisa() => 
            FecharJanelaComEsc();

        public void FecharTelasDeProduto(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            FecharJanelaComEsc();
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}
