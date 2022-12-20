using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Page;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa
{
    public class PesquisaDePessoaPage : PageObjectModel
    {
        public PesquisaDePessoaPage(DriverService driver) : base(driver)
        {
        }

        public void PesquisarPessoa(string tipoPessoa, string nomePessoa)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDePessoaModel.TelaPesquisaPessoaPrefixo + tipoPessoa);
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(PesquisaDePessoaModel.ElementoParametroDePesquisa, nomePessoa, Keys.Enter);
        }

        public void PesquisarPessoaComConfirmar(string tipoPessoa, string nomePessoa)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDePessoaModel.TelaPesquisaPessoaPrefixo + tipoPessoa);
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdComF5(PesquisaDePessoaModel.ElementoParametroDePesquisa, nomePessoa, Keys.Enter);
        }

        public bool VerificarSeExistePessoaNaGrid(string nomePessoa)
        {
            var nomePessoaNaGrid = DriverService.PegarValorDaColunaDaGrid("Nome");
            return nomePessoa.Equals(nomePessoaNaGrid);
        }

        public bool VerificarSeCarregouOsDadosDaPessoa(string campoDaPessoa, string nomeDaPessoa) =>
            DriverService.ObterValorElementoId(campoDaPessoa).Equals(nomeDaPessoa);

        //public void RealizarFluxoDoPesquisarPessoaVazia(ILifetimeScope beginLifetimeScope, string tipoDePessoa)
        //{
        //    // Arange
        //    var resolveCadastroDeCliente = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteFisicoPage>>();
        //    var cadastroDeCliente = resolveCadastroDeCliente(DriverService, new Dictionary<string, string>());
        //    cadastroDeCliente.AcessarTelaDeCadastroDeClienteEPesquisar();

        //    // Act
        //    PesquisarPessoa(tipoDePessoa, "");

        //    // Assert
        //    Assert.True(VerificarSeExisteQualquerPessoaNaGrid());
        //    FecharJanelaComEsc(tipoDePessoa);
        //    cadastroDeCliente.FecharJanelaComEsc();
        //}

        public void RealizarFluxoDoPesquisarPessoaConfirmarSelecao(ILifetimeScope beginLifetimeScope, string tipoDePessoa, string nomeDaPessoa)
        {
            // Arange
            var resolveCadastroDeCliente = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteFisicoPage>>();
            var cadastroDeCliente = resolveCadastroDeCliente(DriverService, new Dictionary<string, string>());
            cadastroDeCliente.AcessarTelaDeCadastroDeClienteEPesquisar();

            // Act
            PesquisarPessoaComConfirmar(tipoDePessoa, nomeDaPessoa);

            // Assert
            Assert.True(VerificarSeCarregouOsDadosDaPessoa(CadastroDeClienteModel.ElementoNome, nomeDaPessoa));
            cadastroDeCliente.FecharJanelaComEsc();
        }

        public bool VerificarSeExisteQualquerPessoaNaGrid() =>
            DriverService.PegarValorDaColunaDaGrid("Nome").Any();

        public bool FecharJanelaComEsc(string tipoPessoa)
        {
            var nomeJanela = PesquisaDePessoaModel.TelaPesquisaPessoaPrefixo + tipoPessoa;
            try
            {
                DriverService.FecharJanelaComEsc(nomeJanela);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }
    }
}
