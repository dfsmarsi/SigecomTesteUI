using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.PesquisaDeCategoria
{
    public class PesquisaDeCategoriaPage : PageObjectModel
    {
        public PesquisaDeCategoriaPage(DriverService driver) : base(driver) { }

        public void PesquisarCategoriaNaTelaDeControle(string nomeDaCategoria) => 
            DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeCategoriaModel.ElementoPesquisar, nomeDaCategoria, Keys.Enter);

        public bool VerificarSeExisteCategoriaNaGrid(string nomeDaCategoria)
        {
            var nomeDaCategoriaNaGrid = DriverService.PegarValorDaColunaDaGrid("Descricao");
            return nomeDaCategoria.Equals(nomeDaCategoriaNaGrid);
        }
    }
}
