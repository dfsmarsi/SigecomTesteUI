using System;

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
    }
}
