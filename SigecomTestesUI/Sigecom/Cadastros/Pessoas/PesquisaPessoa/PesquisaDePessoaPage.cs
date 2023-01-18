using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;
using System;
using System.Linq;
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
            DriverService.DigitarNoCampoComTeclaDeAtalhoIdMaisF5(PesquisaDePessoaModel.ElementoParametroDePesquisa, nomePessoa, Keys.Enter);
        }

        public bool VerificarSeExistePessoaNaGrid(string nomePessoa)
        {
            var nomePessoaNaGrid = DriverService.PegarValorDaColunaDaGrid("Nome");
            return nomePessoa.Equals(nomePessoaNaGrid);
        }

        public bool VerificarSeCarregouOsDadosDaPessoa(string campoDaPessoa, string nomeDaPessoa) =>
            DriverService.ObterValorElementoId(campoDaPessoa).Equals(nomeDaPessoa);

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
