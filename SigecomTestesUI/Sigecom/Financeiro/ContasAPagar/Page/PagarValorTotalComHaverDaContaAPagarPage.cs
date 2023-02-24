using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;
using System;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class PagarValorTotalComHaverDaContaAPagarPage:PageObjectModel
    {
        public PagarValorTotalComHaverDaContaAPagarPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(ContaAPagarModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenu);

        public void RealizarFluxoDePagarValorTotalComHaverNaContaAPagar()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenuDoPagar);

            // Act
            RealizarFluxoDeGerarContaAPagar();
            DriverService.CliqueNoElementoDaGridComVarios("Saldo", "R$22,22");
            ClicarBotaoName(ContaAPagarModel.BotaoDePagar);
            DriverService.SelecionarItensDoDropDown(1);
            DriverService.RealizarSelecaoDaFormaDePagamento(ContaAPagarModel.ElementoDeFormaDePagamento, 4);
            ClicarBotaoName(ContaAPagarModel.Nao);
            FecharTelaDeContaAPagarComEsc();

            // Assert
            ClicarNaOpcaoDoSubMenu();
            DriverService.SelecionarItensDoDropDown(2);
            Assert.AreEqual(DriverService.VerificarSePossuiOValorNaGrid("Valor pago", "R$0,00"), true);
            FecharTelaDeContasRecebidasComEsc();
        }

        private void RealizarFluxoDeGerarContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contaBasePage = beginLifetimeScope.Resolve<Func<DriverService, IContaBasePage>>()(DriverService);
            contaBasePage.RealizarFluxoDeGerarContaAPagar("22,22");
        }

        private void FecharTelaDeContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);

        private void FecharTelaDeContasRecebidasComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagas);
    }
}
