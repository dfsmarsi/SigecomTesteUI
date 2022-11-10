using System;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;

namespace SigecomTestesUI.Sigecom.Pesquisa.PesquisaProduto
{
    public class PesquisaDeProdutoPage : PageObjectModel
    {
        private const string _telaPesquisaDeProdutoPrefixo = "Pesquisa de produto";
        private const string _elementoParametroDePesquisa = "textEditParametroDePesquisa";

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
