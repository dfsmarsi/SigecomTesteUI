using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Teste
{
    public class EdicaoDeColaboradorJuridicoSimplesTeste : BaseTestes
    {
        [Test(Description = "Edição de colaborador jurídico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Colaborador")]
        public void EdicaoDeColaboradorJuridicoSimples()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeClienteFisicoPage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeColaboradorBasePage>>();
            var edicaoDeClienteBasePage = resolveCadastroDeClienteFisicoPage(DriverService);
            const ClassificacaoDePessoa classificacaoDePessoa = ClassificacaoDePessoa.JuridicaSimples;
            edicaoDeClienteBasePage.PesquisarColaboradorQueSeraEditado(classificacaoDePessoa);

            // Act
            edicaoDeClienteBasePage.VerificarInformacoesDoColaborador(classificacaoDePessoa);
            edicaoDeClienteBasePage.PreencherAsInformacoesDaPessoasNaEdicao(classificacaoDePessoa);
            edicaoDeClienteBasePage.Gravar();

            // Assert
            edicaoDeClienteBasePage.FluxoDePesquisaDaPessoaEditado(classificacaoDePessoa);
            edicaoDeClienteBasePage.VerificarDadosDaPessoaEditados(classificacaoDePessoa);
            edicaoDeClienteBasePage.FecharJanelaCadastroDeColaboradorComEsc();
        }
    }
}
