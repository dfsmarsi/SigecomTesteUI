using System;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa
{
    public class PesquisaDePessoaPage : PageObjectModel
    {
        public PesquisaDePessoaPage(DriverService driver) : base(driver) { }

        public void PesquisarPessoa(string tipoPessoa, string nomePessoa)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDePessoaModel.TelaPesquisaPessoaPrefixo + tipoPessoa);
            DriverService.DigitarNoCampoEnterId(PesquisaDePessoaModel.ElementoParametroDePesquisa, nomePessoa);            
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
            catch (Exception)
            {
                return false;
            }
        }
    }
}
