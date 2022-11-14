using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System;

namespace SigecomTestesUI.Sigecom.Pesquisa.PesquisaProduto
{
    public class PesquisaDeProdutoPage : PageObjectModel
    {
        private const string _telaPesquisaDeProdutoPrefixo = "Pesquisa de produtos";
        private const string _elementoParametroDePesquisa = "txtPesquisar";

        public PesquisaDeProdutoPage(DriverService driver) : base(driver) { }

        public void PesquisarProduto(string nomeDoProduto)
        {
            DriverService.ValidarElementoExistentePorNome(_telaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoEnterId(_elementoParametroDePesquisa, nomeDoProduto);
        }

        public bool VerificarSeExisteProdutoNaGrid(string nomeDoProduto)
        {
            var nomeDoProdutoNaGrid = DriverService.PegarValorDaColunaDaGrid("Nome");
            return nomeDoProduto == nomeDoProdutoNaGrid;
        }

        public bool FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(_telaPesquisaDeProdutoPrefixo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
