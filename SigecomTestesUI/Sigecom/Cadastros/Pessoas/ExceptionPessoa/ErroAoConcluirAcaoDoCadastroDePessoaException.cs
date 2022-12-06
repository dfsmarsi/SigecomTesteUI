using System;
using System.Runtime.Serialization;

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

        protected ErroAoConcluirAcaoDoCadastroDePessoaException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}
