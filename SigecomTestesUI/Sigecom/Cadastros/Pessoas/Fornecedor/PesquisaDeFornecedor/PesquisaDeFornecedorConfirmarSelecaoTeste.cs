using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Page;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.PesquisaDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.PesquisaDeFornecedor
{
    public class PesquisaDeFornecedorConfirmarSelecaoTeste : BaseTestes
    {
        [Test(Description = "Pesquisa de fornecedor confirmando a seleção")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Fornecedor")]
        public void PesquisarFornecedorComConfirmarSelecao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);

            // Arange
            var resolveCadastroDeFornecedorFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeFornecedorFisicoPage>>();
            var cadastroDeFornecedorFisicoPage = resolveCadastroDeFornecedorFisicoPage(DriverService, new Dictionary<string, string>());
            cadastroDeFornecedorFisicoPage.AcessarTelaDeCadastroDeFornecedor(false);

            // Act
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("fornecedor", PesquisaDeFornecedorInformacoesParaTesteModel.NomeDaPessoa);

            // Assert
            Assert.True(pesquisaDePessoaPage.VerificarSeCarregouOsDadosDaPessoa(CadastroDeClienteModel.ElementoNome, PesquisaDeFornecedorInformacoesParaTesteModel.NomeDaPessoa));
            cadastroDeFornecedorFisicoPage.FecharJanelaCadastroFornecedorComEsc();
        }
    }
}
