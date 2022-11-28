using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Teste
{
    public class PesquisaDeProdutoBaseTeste: BaseTestes
    {
        public void AbrirTelaDePesquisaDeProduto(Dictionary<string, string> dadosDeProduto, out ILifetimeScope beginLifetimeScope)
        {
            beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            var cadastroDeProdutoPage =
                resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);
            cadastroDeProdutoPage.AcessarAtalhoDePesquisaDeProduto();
        }

        public void AbrirTelaDePesquisaDeProduto(Dictionary<string, string> dadosDeProduto, ILifetimeScope beginLifetimeScope)
        {
            var resolveCadastroDeProdutoPage =
                beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeProdutoPage>>();
            var cadastroDeProdutoPage = resolveCadastroDeProdutoPage(DriverService, dadosDeProduto);
            cadastroDeProdutoPage.AcessarAtalhoDePesquisaDeProduto();
        }
    }
}
