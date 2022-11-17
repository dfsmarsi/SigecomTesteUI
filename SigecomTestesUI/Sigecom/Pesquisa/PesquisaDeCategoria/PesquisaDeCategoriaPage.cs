using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaDeCategoria.Model;
using System;

namespace SigecomTestesUI.Sigecom.Pesquisa.PesquisaDeCategoria
{
    public class PesquisaDeCategoriaPage : PageObjectModel
    {
        public PesquisaDeCategoriaPage(DriverService driver) : base(driver) { }

        public void PesquisarCategoria(string nomeDaCategoria)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeCategoriaModel.TelaPesquisaDeCategoria);
            DriverService.DigitarNoCampoEnterId(PesquisaDeCategoriaModel.ElementoParametroDePesquisa, nomeDaCategoria);
        }

        public bool VerificarSeExisteCategoriaNaGrid(string nomeDaCategoria)
        {
            var nomeDaCategoriaNaGrid = DriverService.PegarValorDaColunaDaGrid("Descricao");
            return nomeDaCategoria == nomeDaCategoriaNaGrid;
        }

        public bool FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(PesquisaDeCategoriaModel.TelaPesquisaDeCategoria);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
