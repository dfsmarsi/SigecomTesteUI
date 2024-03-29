﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page;
using System;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Teste
{
    public class LancarVendaComTrocoTeste: BaseTestes
    {
        [Test(Description = "Lançar itens com troco no dinheiro do PDV")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Lancar")]
        [AllureSubSuite("PDV")]
        public void LancarItensComTrocoNoDinheiroDoPdv()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var lancarVendaComTrocoPage = beginLifetimeScope.Resolve<Func<DriverService, LancarVendaComTrocoPage>>()(DriverService);
            lancarVendaComTrocoPage.RealizarFluxoDeLancarVendaNoPdv();
        }
    }
}
