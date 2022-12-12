using System;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page
{
    public class EdicaoDeProdutoBasePage: PageObjectModel
    {
        public EdicaoDeProdutoBasePage(DriverService driver) : base(driver)
        {
        }

        public bool ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoMenuCadastro);

        public bool ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeProdutoModel.BotaoSubMenuProduto);

        public void ClicarNoAtalhoDePesquisar() =>
            DriverService.AbrirPesquisaDeProdutoComF9(CadastroDeProdutoModel.BotaoPesquisar);

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

        internal void AbrirTelaDeCadastroDoProduto()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
        }

        internal void RetornarPesquisaDeProduto(out PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
        }

        public void VerificarCamposDeProduto(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).VerificarCamposDoProduto();
        }

        public bool PreencherCamposDoProdutoAoEditar(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).PreencherCamposDoProdutoAoEditar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VerificarCamposDoProduto(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).VerificarCamposDoProduto();
        }

        public void VerificarCamposDeProdutoEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).VerificarCamposDeProdutoEditado();
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

        public void VerificarCamposDaAba(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).VerificarCamposDaAba();
        }

        public bool PreencherCamposDaAbaAoEditar(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).PreencherCamposDaAbaAoEditar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VerificarCamposDaAbaEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).VerificarCamposDaAbaEditado();
        }

        public void VerificarCamposDeImpostos()
        {
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoOrigemMercadoria), "0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoSituacaoTributaria), "TRIBUTADO SEM PERMISSÃO DE CRÉDITO");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNaturezaCfop), "Produto adquirido ou recebido de terceiros");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNcm), CadastroDeProdutoBaseModel.NcmDoProduto);
        }

        public bool PreencherCamposDeImpostosAoEditar()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoOrigemMercadoria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoSituacaoTributaria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoNaturezaCfop, 1);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNcm, EdicaoDeProdutoSimplesModel.NcmDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void VerificarCamposDeImpostosEditado()
        {
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoOrigemMercadoria), "1 - Estrangeira - Importação direta, exceto a indicada no código 6");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoSituacaoTributaria), "SUBSTITUIÇÃO TRIBUTÁRIA COBRADA ANTERIORMENTE");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNaturezaCfop), "Produto produzido pelo estabelecimento");
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNcm), EdicaoDeProdutoSimplesModel.NcmDoProduto);
        }

        public void PesquisarProdutoQueSeraEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).PesquisarProdutoQueSeraEditado(this);
        }

        public void RealizarFluxoDePesquisaDoProdutoQueFoiEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto).FluxoDePesquisaDoProdutoEditado(this, pesquisaDeProdutoPage);
        }
    }
}
