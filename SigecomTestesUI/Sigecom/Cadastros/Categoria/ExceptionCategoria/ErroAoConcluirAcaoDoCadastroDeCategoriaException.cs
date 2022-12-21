using System;
using System.Runtime.Serialization;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.ExceptionCategoria
{
    public class ErroAoConcluirAcaoDoCadastroDeCategoriaException : Exception
    {
        public ErroAoConcluirAcaoDoCadastroDeCategoriaException()
        {
        }

        public ErroAoConcluirAcaoDoCadastroDeCategoriaException(string mensagem) : base(mensagem)
        {
        }

        public ErroAoConcluirAcaoDoCadastroDeCategoriaException(string mensagem, Exception innerException) : base(mensagem,
            innerException)
        {
        }

        protected ErroAoConcluirAcaoDoCadastroDeCategoriaException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}
