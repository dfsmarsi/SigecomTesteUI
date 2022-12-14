using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces
{
    public interface IEdicaoDeClienteFisicoPage
    {
        void VerificarDadosDaPessoa();
        void PreencherAsInformacoesDaPessoasNaEdicao();
        void VerificarDadosDaPessoaEditados();
        void FluxoDePesquisaDaPessoaEditado(CadastroDeClienteFisicoPage cadastroDeClienteFisicoPage,
            PesquisaDePessoaPage pesquisaDePessoaPage);
    }
}
