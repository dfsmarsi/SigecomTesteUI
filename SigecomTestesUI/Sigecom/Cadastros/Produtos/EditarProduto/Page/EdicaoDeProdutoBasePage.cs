using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page.Interface;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.ExceptionProduto;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Enum;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Page
{
    public class EdicaoDeProdutoBasePage : PageObjectModel
    {
        public EdicaoDeProdutoBasePage(DriverService driver) : base(driver)
        {
        }

        public bool ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeProdutoModel.BotaoMenuCadastro);

        public bool ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeProdutoModel.BotaoSubMenuProduto);

        public void ClicarNoAtalhoDePesquisar() =>
            DriverService.AbrirPesquisaComF9(CadastroDeProdutoModel.BotaoPesquisar);

        public bool Gravar()
        {
            try
            {
                DriverService.DarDuploCliqueNoBotaoName(CadastroDeProdutoModel.BotaoGravar);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDeProdutoException(exception.ToString());
            }
        }


        public bool FecharJanelaCadastroDeProdutoComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeProdutoModel.ElementoTelaCadastroDeProduto);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDeProdutoException(exception.ToString());
            }
        }

        internal void AbrirTelaDeCadastroDoProduto()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
        }

        public void RealizarFluxoDoEditarProduto(TipoDeProduto tipoDeProduto, string aba)
        {
            // Arange
            PesquisarProdutoQueSeraEditado(tipoDeProduto);

            // Act
            VerificarCamposDoProduto(tipoDeProduto);
            PreencherCamposDoProdutoAoEditar(tipoDeProduto);
            AcessarAba(aba);
            VerificarCamposDaAba(tipoDeProduto);
            PreencherCamposDaAbaAoEditar(tipoDeProduto);
            Gravar();

            // Assert
            RealizarFluxoDePesquisaDoProdutoQueFoiEditado(tipoDeProduto);
            AcessarAba(aba);
            VerificarCamposDaAbaEditado(tipoDeProduto);
            FecharJanelaCadastroDeProdutoComEsc();
        }

        internal void RetornarPesquisaDeProduto(out PesquisaDeProdutoPage pesquisaDeProdutoPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDeProdutoPage>>();
            pesquisaDeProdutoPage = resolvePesquisaDeProdutoPage(DriverService);
        }

        public void VerificarCamposDoProduto(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto)
                .VerificarCamposDoProduto();
        }

        public bool PreencherCamposDoProdutoAoEditar(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto)
                    .PreencherCamposDoProdutoAoEditar();
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDeProdutoException(exception.ToString());
            }
        }

        public void VerificarCamposDeProdutoEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto)
                .VerificarCamposDeProdutoEditado();
        }

        public bool AcessarAba(string aba)
        {
            try
            {
                DriverService.ClicarBotaoName(aba);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDeProdutoException(exception.ToString());
            }
        }

        public void VerificarCamposDaAba(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto)
                .VerificarCamposDaAba();
        }

        public bool PreencherCamposDaAbaAoEditar(TipoDeProduto tipoDeProduto)
        {
            try
            {
                using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
                beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto)
                    .PreencherCamposDaAbaAoEditar();
                EsperarAcaoEmSegundos(1);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDeProdutoException(exception.ToString());
            }
        }

        public void VerificarCamposDaAbaEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto)
                .VerificarCamposDaAbaEditado();
        }

        public void VerificarCamposDeImpostos()
        {
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoOrigemMercadoria),
                CadastroDeProdutoBaseModel.OrigemMercadoria);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoSituacaoTributaria),
                CadastroDeProdutoBaseModel.SituacaoTributaria);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNaturezaCfop),
                CadastroDeProdutoBaseModel.NaturezaCfop);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNcm),
                CadastroDeProdutoBaseModel.NcmDoProduto);
        }

        public bool PreencherCamposDeImpostosAoEditar()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoOrigemMercadoria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoSituacaoTributaria, 1);
                DriverService.SelecionarItemComboBox(CadastroDeProdutoModel.ElementoNaturezaCfop, 1);
                DriverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNcm,
                    EdicaoDeProdutoSimplesModel.NcmDoProduto);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDeProdutoException(exception.ToString());
            }
        }

        public void VerificarCamposDeImpostosEditado()
        {
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoOrigemMercadoria),
                EdicaoDeProdutoSimplesModel.OrigemMercadoria);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoSituacaoTributaria),
                EdicaoDeProdutoSimplesModel.SituacaoTributaria);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNaturezaCfop),
                EdicaoDeProdutoSimplesModel.NaturezaCfop);
            Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNcm),
                EdicaoDeProdutoSimplesModel.NcmDoProduto);
        }

        public void PesquisarProdutoQueSeraEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto)
                .PesquisarProdutoQueSeraEditado(this);
        }

        public void RealizarFluxoDePesquisaDoProdutoQueFoiEditado(TipoDeProduto tipoDeProduto)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            RetornarPesquisaDeProduto(out var pesquisaDeProdutoPage);
            beginLifetimeScope.Resolve<IEdicaoDeProdutoPageFactory>().Fabricar(DriverService, tipoDeProduto)
                .FluxoDePesquisaDoProdutoEditado(this, pesquisaDeProdutoPage);
        }
    }
}
