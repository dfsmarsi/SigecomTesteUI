using System;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class PagarContaPage:PageObjectModel
    {
        public PagarContaPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAPagarModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenu);

        public void RealizarFluxoDePagarValorTotalNaContaAPagar()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenuDoPagar);

            // Act
            RealizarFluxoDeGerarContaAPagar();
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$11,11");
            ClicarBotaoName(ContaAPagarModel.BotaoDePagar);
            DriverService.SelecionarItensDoDropDown(1);
            DriverService.RealizarSelecaoDaFormaDePagamento(ContaAPagarModel.ElementoDeFormaDePagamento, 1);
            FecharTelaDeContaAPagarComEsc();

            // Assert
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(2);
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Valor pago", "R$11,11"), true);
            FecharTelaDeContasRecebidasComEsc();
        }

        private void RealizarFluxoDeGerarContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contaBasePage = beginLifetimeScope.Resolve<Func<DriverService, IContaBasePage>>()(DriverService);
            contaBasePage.RealizarFluxoDeGerarContaAPagar("11,11");
        }

        private void FecharTelaDeContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);

        private void FecharTelaDeContasRecebidasComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagas);
    }
}
