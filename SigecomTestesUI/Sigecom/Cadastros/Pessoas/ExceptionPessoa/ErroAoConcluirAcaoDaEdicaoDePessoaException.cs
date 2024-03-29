﻿using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa
{
    public class ErroAoConcluirAcaoDaEdicaoDePessoaException : Exception
    {
        public ErroAoConcluirAcaoDaEdicaoDePessoaException()
        {
        }

        public ErroAoConcluirAcaoDaEdicaoDePessoaException(string mensagem) : base(mensagem)
        {
        }

        public ErroAoConcluirAcaoDaEdicaoDePessoaException(string mensagem, Exception innerException) : base(mensagem,
            innerException)
        {
        }
    }
}
