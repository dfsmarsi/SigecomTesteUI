using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa
{
    public class ErroAoConcluirAcaoDoCadastroDePessoaException : Exception
    {
        public ErroAoConcluirAcaoDoCadastroDePessoaException()
        {
        }

        public ErroAoConcluirAcaoDoCadastroDePessoaException(string mensagem) : base(mensagem)
        {
        }

        public ErroAoConcluirAcaoDoCadastroDePessoaException(string mensagem, Exception innerException) : base(mensagem,
            innerException)
        {
        }
    }
}
