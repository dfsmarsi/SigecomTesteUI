﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.Pedido.Teste
{
    public class LancarVendaDeDinheiroNoPedidoTeste: BaseTestes
    {
        [Test(Description = "Lançar itens no dinheiro do PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("Pedido")]
        public void LancarItensNoDinheiroDinheiroDoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarVendaDeDinheiroNoPedidoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarVendaDeDinheiroNoPedidoPage>>()(DriverService);
            lancarVendaDeDinheiroNoPedidoPage.RealizarFluxoDeLancarVendaDeDinheiroNoPedido();
        }
    }
}
