using System;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.PesquisaDeCategoria.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.PesquisaDeCategoria
{
    public class PesquisaDeCategoriaPage : PageObjectModel
    {
        public PesquisaDeCategoriaPage(DriverService driver) : base(driver) { }

        public void PesquisarCategoria(string nomeDaCategoria)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeCategoriaModel.TelaPesquisaDeCategoria);
            DriverService.DigitarNoCampoEnterId(PesquisaDeCategoriaModel.ElementoParametroDePesquisa, nomeDaCategoria);
        }

        public void PesquisarCategoriaNaTelaDeControle(string nomeDaCategoria) => 
            DriverService.DigitarNoCampoEnterId(CadastroDeCategoriaModel.ElementoPesquisar, nomeDaCategoria);

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
