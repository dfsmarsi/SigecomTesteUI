using System;

namespace SigecomTestesUI.Sigecom.Cadastros.TabelaDePreco.ExceptionTabelaDePreco
{
    public class ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException: Exception
    {
        public ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException()
        {
        }

        public ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException(string mensagem) : base(mensagem)
        {
        }

        public ErroAoConcluirAcaoDoCadastroDeTabelaDePrecoException(string mensagem, Exception innerException) : base(mensagem,
            innerException)
        {
        }
    }
}
