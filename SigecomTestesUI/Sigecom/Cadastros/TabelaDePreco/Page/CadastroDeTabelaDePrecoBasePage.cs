using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.ExceptionTabelaDePreco;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Model;
using SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page.Interfaces;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.Page
{
    public class CadastroDeTabelaDePrecoBasePage : PageObjectModel
    {
        public CadastroDeTabelaDePrecoBasePage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeTabelaDePrecoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeTabelaDePrecoModel.BotaoSubMenu);

        private void ClicarNoBotaoNovo() =>
            ClicarBotao(CadastroDeTabelaDePrecoModel.ElementoBotaoNovo);

        public void ClicarNoBotaoAplicar() =>
            ClicarBotao(CadastroDeTabelaDePrecoModel.ElementoAplicarRegra);

        public void AdicionarUmaNovaTabelaDePreco()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarNoBotaoNovo();
        }

        public void PreencherCamposDaTabela(QuantidadeDeProdutoParaTabelaDePreco quantidadeDeProdutoParaTabelaDePreco)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<ICadastroDeTabelaDePrecoPageFactory>().Fabricar(DriverService, quantidadeDeProdutoParaTabelaDePreco).PreencherCamposDaTabela();
        }

        public void VerificarCamposDaGridDeProdutos()
        {
            Assert.Equals(DriverService.PegarValorDaColunaDaGrid("Markup na tabela(%)"), CadastroDeTabelaDePrecoModel.MarkupNaTabela);
            Assert.Equals(DriverService.PegarValorDaColunaDaGrid("Valor na tabela"), CadastroDeTabelaDePrecoModel.ValorNaTabela);
        }

        public void ClicarNoBotaoGravar() =>
            ClicarBotao(CadastroDeTabelaDePrecoModel.ElementoGravar);

        public void FecharJanelaCadastroComEsc()
        {
            try
            {
                DriverService.DisposeComTelaAberta();
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException(exception.ToString());
            }
        }
    }
}
