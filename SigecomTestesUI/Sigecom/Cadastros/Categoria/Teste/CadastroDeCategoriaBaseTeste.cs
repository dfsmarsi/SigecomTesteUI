using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.PesquisaDeCategoria;
using System;
using System.Collections.Generic;
using SigecomTestesUI.ControleDeInjecao;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaBaseTeste: BaseTestes
    {
        public void RetornarCadastroDeCategoria(Dictionary<string, string> dadosDeCategoria,
            out CadastroDeCategoriaPage cadastroDeCategoriaPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeCategoriaPage = beginLifetimeScope
                .Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeCategoriaPage>>();
            cadastroDeCategoriaPage = resolveCadastroDeCategoriaPage(DriverService, dadosDeCategoria);
        }
        
        public void AbrirTelaDeCategoriaParaTeste(CadastroDeCategoriaPage cadastroDeCategoriaPage)
        {
            cadastroDeCategoriaPage.ClicarNaOpcaoDoMenu();
            cadastroDeCategoriaPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeCategoriaPage.ClicarNoBotaoNovoCategoria();
            cadastroDeCategoriaPage.ClicarNoBotaoNovo();
        }

        public void PesquisarCategoriaGravada(CadastroDeCategoriaPage cadastroDeCategoriaPage, IReadOnlyDictionary<string, string> dadosDoCadastro)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            cadastroDeCategoriaPage.ClicarNaOpcaoDoPesquisar();
            var resolvePesquisaDeCategoriaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeCategoriaPage>>();
            var pesquisaDeCategoriaPage = resolvePesquisaDeCategoriaPage(DriverService);
            pesquisaDeCategoriaPage.PesquisarCategoria(dadosDoCadastro["Grupo"]);
            Assert.True(pesquisaDeCategoriaPage.VerificarSeExisteCategoriaNaGrid(dadosDoCadastro["Grupo"]));
            pesquisaDeCategoriaPage.FecharJanelaComEsc();
            cadastroDeCategoriaPage.FecharJanelaCadastroDeCategoriaComEsc(
                CadastroDeCategoriaModel.ElementoTelaCadastroDeCategoria);
            cadastroDeCategoriaPage.FecharJanelaCadastroDeCategoriaComEsc(
                CadastroDeCategoriaModel.ElementoTelaControleDeCategoria);
        }
    }
}
