using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.CadastroDeCliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Enum;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page
{
    public class EdicaoDeClienteBasePage: PageObjectModel
    {
        public EdicaoDeClienteBasePage(DriverService driver) : base(driver) { }
        
        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeClienteModel.BotaoMenu);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeClienteModel.BotaoSubMenu);

        public void ClicarNoAtalhoDePesquisar() =>
            DriverService.AbrirPesquisaComF9(CadastroDeClienteModel.BotaoPesquisar);

        public void AbrirTelaDeCadastroDeCliente()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
        }

        public void RealizarFluxoDaEdicaoDeCliente(ClassificacaoDePessoa classificacaoDePessoa)
        {
            // Arange
            PesquisarClienteQueSeraEditado(classificacaoDePessoa);

            // Act
            VerificarInformacoesDoCliente(classificacaoDePessoa);
            PreencherAsInformacoesDaPessoasNaEdicao(classificacaoDePessoa);
            Gravar();

            // Assert
            FluxoDePesquisaDaPessoaEditado(classificacaoDePessoa);
            VerificarDadosDaPessoaEditados(classificacaoDePessoa);
            FecharJanelaCadastroDeClienteComEsc();
        }

        private void PesquisarClienteQueSeraEditado(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeClientePage.PesquisarClienteQueSeraEditado(this);
        }

        private void VerificarInformacoesDoCliente(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeClientePage.VerificarDadosDaPessoa();
        }

        private void PreencherAsInformacoesDaPessoasNaEdicao(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeClientePage.PreencherAsInformacoesDaPessoasNaEdicao();
        }

        private void Gravar() =>
            DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoGravar);

        internal void RetornarPesquisaDePessoa(out PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
        }

        private void FluxoDePesquisaDaPessoaEditado(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            edicaoDeClientePage.FluxoDePesquisaDaPessoaEditado(this, pesquisaDePessoaPage);
        }

        private void VerificarDadosDaPessoaEditados(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeClientePage.VerificarDadosDaPessoaEditados();
        }

        private void FecharJanelaCadastroDeClienteComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeClienteModel.ElementoTelaCadastroCliente);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDePessoaException($"{exception}");
            }
        }
    }
}
