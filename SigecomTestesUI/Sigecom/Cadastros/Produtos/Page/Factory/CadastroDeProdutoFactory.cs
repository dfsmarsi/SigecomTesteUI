using Autofac.Features.Indexed;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.Page.Factory
{
    public class CadastroDeProdutoFactory : ICadastroDeProdutoFactory
    {
        private readonly IIndex<TipoDeProduto, ICadastroDeProdutoPage> _cadastroDeProdutoPage;

        public CadastroDeProdutoFactory(IIndex<TipoDeProduto, ICadastroDeProdutoPage> cadastroDeProdutoPage) =>
            _cadastroDeProdutoPage = cadastroDeProdutoPage;

        public ICadastroDeProdutoPage Fabricar(DriverService driverService, TipoDeProduto tipoDeProduto)
        {
            //return _cadastroDeProdutoPage[tipoDeProduto];

            if (tipoDeProduto.Equals(TipoDeProduto.Balanca))
            {
                return new CadastroDeProdutoBalancaPage(driverService);
            }

            return new CadastroDeProdutoSimplesPage(driverService);
        }
    }
}
