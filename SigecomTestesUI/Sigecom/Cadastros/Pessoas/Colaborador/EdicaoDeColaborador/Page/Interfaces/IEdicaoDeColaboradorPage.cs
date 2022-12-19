using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces
{
    public interface IEdicaoDeColaboradorPage
    {
        void PesquisarColaboradorQueSeraEditado(EdicaoDeColaboradorBasePage edicaoDeColaboradorBasePage);
        void VerificarDadosDaPessoa();
        void PreencherAsInformacoesDaPessoasNaEdicao();
        void VerificarDadosDaPessoaEditados();
        void FluxoDePesquisaDaPessoaEditado(EdicaoDeColaboradorBasePage edicaoDeColaboradorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage);
    }
}
