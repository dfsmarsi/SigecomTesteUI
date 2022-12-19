using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Teste
{
    public class EdicaoDeFornecedorJuridicaSimplesTeste: BaseTestes
    {
        [Test(Description = "Edição de fornecedor físico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Fornecedor")]
        public void EdicaoDeFornecedorFisicoSimples()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeFornecedorBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeFornecedorBasePage>>();
            var edicaoDeFornecedorBasePage = resolveEdicaoDeFornecedorBasePage(DriverService);
            const ClassificacaoDePessoa classificacaoDePessoa = ClassificacaoDePessoa.JuridicaSimples;
            edicaoDeFornecedorBasePage.PesquisarFornecedorQueSeraEditado(classificacaoDePessoa);

            // Act
            edicaoDeFornecedorBasePage.VerificarInformacoesDoFornecedor(classificacaoDePessoa);
            edicaoDeFornecedorBasePage.PreencherAsInformacoesDaPessoasNaEdicao(classificacaoDePessoa);
            edicaoDeFornecedorBasePage.Gravar();

            // Assert
            edicaoDeFornecedorBasePage.FluxoDePesquisaDaPessoaEditado(classificacaoDePessoa);
            edicaoDeFornecedorBasePage.VerificarDadosDaPessoaEditados(classificacaoDePessoa);
            edicaoDeFornecedorBasePage.FecharJanelaCadastroDeFornecedorComEsc();
        }
    }
}
