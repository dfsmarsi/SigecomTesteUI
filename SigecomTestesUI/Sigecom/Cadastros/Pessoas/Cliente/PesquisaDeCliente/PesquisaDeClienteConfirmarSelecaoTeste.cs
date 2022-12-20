using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.PesquisaDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Page;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.PesquisaDeCliente
{
    public class PesquisaDeClienteConfirmarSelecaoTeste: BaseTestes
    {
        [Test(Description = "Pesquisa de cliente confirmando a seleção")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Pesquisa")]
        [AllureSubSuite("Cliente")]
        public void PesquisarClienteComConfirmarSelecao()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);

            // Arange
            var resolveCadastroDeCliente = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteFisicoPage>>();
            var cadastroDeCliente = resolveCadastroDeCliente(DriverService, new Dictionary<string, string>());
            cadastroDeCliente.AcessarTelaDeCadastroDeClienteEPesquisar();

            // Act
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("cliente", PesquisaDeClienteInformacoesParaTesteModel.NomeDaPessoa);

            // Assert
            Assert.True(pesquisaDePessoaPage.VerificarSeCarregouOsDadosDaPessoa(CadastroDeClienteModel.ElementoNome, PesquisaDeClienteInformacoesParaTesteModel.NomeDaPessoa));
            cadastroDeCliente.FecharJanelaComEsc();
        }
    }
}
