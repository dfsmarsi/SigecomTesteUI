using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste.Interfaces
{
    public interface ICadastroDeCategoriaBaseTeste
    {
        void RetornarCadastroDeCategoria(Dictionary<string, string> dadosDeCategoria,
            out CadastroDeCategoriaPage cadastroDeCategoriaPage);

        void AbrirTelaDeCategoriaParaTeste(CadastroDeCategoriaPage cadastroDeCategoriaPage);

        void PesquisarCategoriaGravada(CadastroDeCategoriaPage cadastroDeCategoriaPage,
            IReadOnlyDictionary<string, string> dadosDoCadastro);

    }
}
