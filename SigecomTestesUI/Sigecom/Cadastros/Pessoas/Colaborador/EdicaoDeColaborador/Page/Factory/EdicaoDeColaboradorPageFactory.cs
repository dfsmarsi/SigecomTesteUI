﻿using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Enum;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Factory
{
    public class EdicaoDeColaboradorPageFactory: IEdicaoDeColaboradorPageFactory
    {
        public IEdicaoDeColaboradorPage Fabricar(DriverService driverService, ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var life = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            return classificacaoDePessoa switch
            {
                ClassificacaoDePessoa.FisicaSimples => life.Resolve<Func<DriverService, EdicaoDeColaboradorFisicoSimplesPage>>()(driverService),
                ClassificacaoDePessoa.JuridicaSimples => life.Resolve<Func<DriverService, EdicaoDeColaboradorJuridicoSimplesPage>>()(driverService),
                ClassificacaoDePessoa.FisicaCompleta => life.Resolve<Func<DriverService, EdicaoDeColaboradorFisicoCompletoPage>>()(driverService),
                ClassificacaoDePessoa.JuridicaCompleta => life.Resolve<Func<DriverService, EdicaoDeColaboradorJuridicoCompletoPage>>()(driverService),
                _ => throw new ArgumentOutOfRangeException(nameof(classificacaoDePessoa), classificacaoDePessoa, null)
            };
        }
    }
}
