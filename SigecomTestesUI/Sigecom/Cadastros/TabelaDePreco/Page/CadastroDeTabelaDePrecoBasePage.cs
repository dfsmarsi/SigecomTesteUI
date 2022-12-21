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

        public void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeTabelaDePrecoModel.BotaoMenuCadastro);

        public void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeTabelaDePrecoModel.BotaoSubMenu);

        public void ClicarNoBotaoNovo() =>
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
            beginLifetimeScope.Resolve<ICadastroDeTabelaDePrecoPageFactory>().Fabricar(DriverService, quantidadeDeProdutoParaTabelaDePreco);
        }

        public void VerificarCamposDaGridDeProdutos()
        {
            Assert.Equals(DriverService.PegarValorDaColunaDaGrid("Markup na tabela(%)"), CadastroDeTabelaDePrecoModel.MarkupNaTabela);
            Assert.Equals(DriverService.PegarValorDaColunaDaGrid("Valor na tabela"), CadastroDeTabelaDePrecoModel.ValorNaTabela);
        }

        public void FecharJanelaCadastroComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeTabelaDePrecoModel.ElementoTelaCadastroDeTabelaDePreco);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException(exception.ToString());
            }
        }
    }
}
