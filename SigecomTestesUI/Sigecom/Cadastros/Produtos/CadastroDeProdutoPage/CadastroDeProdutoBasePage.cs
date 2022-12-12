using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Login.Model;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;

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

        internal static void AbrirTelaDeCadastroDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage)
        {
            cadastroDeProdutoBasePage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoBasePage.ClicarNaOpcaoDoSubMenu();
        }

        internal void RetornarPesquisaDeProduto(out PesquisaDeProdutoPage pesquisaDeProdutoPage)
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
    }
}
