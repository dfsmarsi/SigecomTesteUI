using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;

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

        public void PesquisarProdutoComConfirmar(string nomeDoProduto)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoIdEnterComF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa, nomeDoProduto);
        }

        public bool VerificarSeExisteProdutoNaGrid(string nomeDoProduto)
        {
            var nomeDoProdutoNaGrid = DriverService.PegarValorDaColunaDaGrid("Nome");
            return nomeDoProduto.Equals(nomeDoProdutoNaGrid);
        }

        public bool VerificarSeCarregouOsDadosDoProduto(Dictionary<string, string> dadosDeProduto) => 
            DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNomeProduto).Equals(dadosDeProduto["NomeFinal"]);

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

        public void PesquisarComF9UmProdutoNaTelaDeCadastroDeProduto(ILifetimeScope beginLifetimeScope, Dictionary<string, string> dadosDeProduto,
            out CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);
            PesquisarUmProdutoNaTelaDeCadastroDeProduto(cadastroDeProdutoPage);
        }

        private static void PesquisarUmProdutoNaTelaDeCadastroDeProduto(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            cadastroDeProdutoPage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisar();
        }

        public void FecharTelasDeProduto(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            FecharJanelaComEsc();
            cadastroDeProdutoPage.FecharJanelaCadastroDeProdutoComEsc();
        }
    }
}
