using System;
using System.Runtime.Serialization;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.ExceptionProduto
{
    public class ErroAoConcluirAcaoDaEdicaoDeProdutoException : Exception
    {
        public ErroAoConcluirAcaoDaEdicaoDeProdutoException()
        {
        }

        public ErroAoConcluirAcaoDaEdicaoDeProdutoException(string mensagem) : base(mensagem)
        {
        }

        public ErroAoConcluirAcaoDaEdicaoDeProdutoException(string mensagem, Exception innerException) : base(mensagem,
            innerException)
        {
        }

        protected ErroAoConcluirAcaoDaEdicaoDeProdutoException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}
