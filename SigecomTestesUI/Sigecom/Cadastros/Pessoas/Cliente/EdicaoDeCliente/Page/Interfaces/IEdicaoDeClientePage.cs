using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces
{
    public interface IEdicaoDeClientePage
    {
        void PesquisarClienteQueSeraEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage);
        void VerificarDadosDaPessoa();
        void PreencherAsInformacoesDaPessoasNaEdicao();
        void VerificarDadosDaPessoaEditados();
        void FluxoDePesquisaDaPessoaEditado(EdicaoDeClienteBasePage edicaoDeClienteBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage);
    }
}
