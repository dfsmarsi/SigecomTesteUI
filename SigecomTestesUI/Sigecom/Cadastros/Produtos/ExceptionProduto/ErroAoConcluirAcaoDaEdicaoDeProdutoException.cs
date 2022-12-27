using System;

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
    }
}
