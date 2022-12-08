using System;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Login.Model;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage
{
    public class CadastroDeProdutoBasePage : PageObjectModel
    {
        public CadastroDeProdutoBasePage(DriverService driver) : base(driver) { }

        public bool ClicarNaOpcaoDoMenu() => 
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoMenuCadastro);

        public bool ClicarNaOpcaoDoSubMenu() => 
            AcessarOpcaoSubMenu(CadastroDeProdutoModel.BotaoSubMenuProduto);

        public void ClicarNoAtalhoDePesquisar() =>
            DriverService.AbrirPesquisaDeProdutoComF9(CadastroDeProdutoModel.BotaoPesquisar);

        public void ClicarNoAtalhoDePesquisarNaTelaPrincipal() =>
            DriverService.AbrirPesquisaDeProdutoComF9(LoginPageModel.ElementoTelaPrincipal);

        public bool ClicarNoBotaoNovo()
        {
            try
            {
                ClicarBotao(CadastroDeProdutoModel.BotaoNovoCadastro);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDoProduto(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto).PreencherCamposDoProduto();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VerificarCamposDeProduto(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto).VerificarCamposDoProduto();
        }

        public bool PreencherCamposDoProdutoAoEditar(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto).PreencherCamposDoProdutoAoEditar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VerificarCamposDeProdutoEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto).VerificarCamposDoProduto();
        }

        public bool PreencherCamposDaAba(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto).PreencherCamposDaAba();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDaAbaAoEditar(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto).PreencherCamposDoProdutoAoEditar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarSePrecoDeVendaFoiCalculado()
        {
            var precoDeVenda = double.Parse(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoPrecoVenda));
            return precoDeVenda.Equals(double.Parse(CadastroDeProdutoBaseModel.PrecoVendaDoProduto));
        }

        public bool AcessarAba(string aba)
        {
            try
            {
                DriverService.ClicarBotaoName(aba);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDeImpostos()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoOrigemMercadoria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoSituacaoTributaria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoNaturezaCfop, 1);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNcm, CadastroDeProdutoBaseModel.NcmDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VerificarCamposDeImpostos()
        {
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoOrigemMercadoria), "0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoSituacaoTributaria), "TRIBUTADO SEM PERMISSÃO DE CRÉDITO");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNaturezaCfop), "Produto adquirido ou recebido de terceiros");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNcm), CadastroDeProdutoBaseModel.NcmDoProduto);
        }

        public bool PreencherCamposDeImpostosDeServico()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoSituacaoTributaria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoNaturezaCfop, 1);
                var verificarNcm = DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNcm).Equals("00000000");
                Assert.True(verificarNcm);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Gravar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeProdutoModel.BotaoGravar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void GravarAoEditarEFecharATela()
        {
            DriverService.GravarCadastroDeProdutoAoEditar(CadastroDeProdutoModel.ElementoTelaCadastroDeProduto);
            FecharJanelaCadastroDeProdutoComEsc();
        }

        public bool FecharJanelaCadastroDeProdutoComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeProdutoModel.ElementoTelaCadastroDeProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AdicionarUmNovoProdutoNaTelaDeCadastroDeProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage)
        {
            AbrirTelaDeCadastroDoProduto(cadastroDeProdutoBasePage);
            cadastroDeProdutoBasePage.ClicarNoBotaoNovo();
        }

        public void EditarProdutoNaTelaDeCadastroDeProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage)
        {
            AbrirTelaDeCadastroDoProduto(cadastroDeProdutoBasePage);
            ClicarNoAtalhoDePesquisar();
            RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(CadastroDeProdutoSimplesModel.NomeDoProduto);
        }

        private static void AbrirTelaDeCadastroDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage)
        {
            cadastroDeProdutoBasePage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoBasePage.ClicarNaOpcaoDoSubMenu();
        }

        private void RetornarPesquisaDeProduto(out PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
        }

        public void RealizarFluxoDePesquisaDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage, TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto).FluxoDePesquisaDoProduto(cadastroDeProdutoBasePage, pesquisaDeProdutoPage);
        }

        public void RealizarFluxoDePesquisaDoProdutoParaOEditar(CadastroDeProdutoBasePage cadastroDeProdutoBasePage, TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            beginLifetimeScope.Resolve<ICadastroDeProdutoFactory>().Fabricar(DriverService, tipoDeProduto).FluxoDePesquisaDoProdutoEditado(cadastroDeProdutoBasePage, pesquisaDeProdutoPage);
        }
    }
}
