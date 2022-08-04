using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SigecomTesteUI
{
    [TestClass]
    public class CadastroFornecedor : Base
    {
        [TestMethod]
        public void CadastrarFornecedorNovo()
        {
            var dictionaryDados = new Dictionary<string, string>() {
                { "Nome", "Correios" },
                { "Cpf", "385.648.790-50" },
                { "Rg", "123456789112" },
                { "Cep", "15700-082" },
                { "Numero", "123" }
            };
            pageTeste = new CadastroFornecedorPage(DriverService);
            pageTeste.RealizarTeste(dictionaryDados);
        }
    }
}
