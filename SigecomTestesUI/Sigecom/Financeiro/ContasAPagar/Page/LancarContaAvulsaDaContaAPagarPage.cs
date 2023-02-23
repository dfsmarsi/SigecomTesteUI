using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Financeiro.BaseDasContas.Interfaces;
using SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Model;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Financeiro.ContasAPagar.Page
{
    public class LancarContaAvulsaDaContaAPagarPage:PageObjectModel
    {
        public LancarContaAvulsaDaContaAPagarPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(ContaAPagarModel.BotaoMenuFinanceiro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenu);

        public void RealizarFluxoDeLancarContaAvulsaNaContaAPagar()
        {
            // Arange
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AcessarOpcaoSubMenu(ContaAPagarModel.BotaoSubMenuDoPagar);

            // Act
            RealizarFluxoDeGerarContaAPagar();

            // Assert
            var posicao = DriverService.RetornarPosicaoDoRegistroDesejado("Saldo", "R$3,34");
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$3,34");
            VerificarValorDoSaldoNaPosicao(posicao + 1);
            VerificarValorDoSaldoNaPosicao(posicao + 2);
            FecharTelaDeLancarContaAvulsaContaAPagarComEsc();
        }

        private void RealizarFluxoDeGerarContaAPagar()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var contaBasePage = beginLifetimeScope.Resolve<Func<DriverService, IContaBasePage>>()(DriverService);
            contaBasePage.RealizarFluxoDeGerarContaAPagar("10");
        }

        private void VerificarValorDoSaldoNaPosicao(int posicao) =>
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGridNaPosicao("Saldo", posicao.ToString()), "R$3,33");

        private void FecharTelaDeLancarContaAvulsaContaAPagarComEsc() =>
            DriverService.FecharJanelaComEsc(ContaAPagarModel.ElementoTelaDeContaPagar);
    }
}
