using System;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;
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
            return nomePessoa == nomePessoaNaGrid;
        }

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
