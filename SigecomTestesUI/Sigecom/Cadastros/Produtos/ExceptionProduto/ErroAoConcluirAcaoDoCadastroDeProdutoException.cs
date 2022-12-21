using System;
using System.Runtime.Serialization;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.ExceptionProduto
{
    public class ErroAoConcluirAcaoDoCadastroDeProdutoException : Exception
    {
        public ErroAoConcluirAcaoDoCadastroDeProdutoException()
        {
        }

        public ErroAoConcluirAcaoDoCadastroDeProdutoException(string mensagem) : base(mensagem)
        {
        }

        public ErroAoConcluirAcaoDoCadastroDeProdutoException(string mensagem, Exception innerException) : base(mensagem,
            innerException)
        {
        }

        protected ErroAoConcluirAcaoDoCadastroDeProdutoException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}
