using Autofac;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste
{
    public class PesquisaDeProdutoBaseTeste: BaseTestes
    {
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
            AbrirTelaDeCadastroDoProduto(cadastroDeProdutoPage);
            cadastroDeProdutoPage.ClicarNoAtalhoDePesquisar();
        }

        private static void AbrirTelaDeCadastroDoProduto(CadastroDeProdutoPage cadastroDeProdutoPage)
        {
            cadastroDeProdutoPage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoPage.ClicarNaOpcaoDoSubMenu();
        }
    }
}
