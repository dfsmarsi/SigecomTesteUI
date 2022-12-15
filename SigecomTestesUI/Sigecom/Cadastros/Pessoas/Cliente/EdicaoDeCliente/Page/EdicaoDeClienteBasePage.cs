using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.EdicaoDeCliente.Page.Interfaces;

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
            DriverService.AbrirPesquisaDeProdutoComF9(CadastroDeClienteModel.BotaoPesquisar);

        private void ClicarBotaoNovo()
        {
            try
            {
                ClicarBotao(CadastroDeClienteModel.BotaoNovo);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void AbrirTelaDeCadastroDeCliente()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
        }

        public void PesquisarProdutoQueSeraEditado(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeClientePage.PesquisarClienteQueSeraEditado(this);
        }

        public void VerificarInformacoesDoCliente(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeClientePage.VerificarDadosDaPessoa();
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeClientePage.PreencherAsInformacoesDaPessoasNaEdicao();
        }

        internal void RetornarPesquisaDePessoa(out PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
        }

        public void FluxoDePesquisaDaPessoaEditado(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            edicaoDeClientePage.FluxoDePesquisaDaPessoaEditado(this, pesquisaDePessoaPage);
        }

        public void VerificarDadosDaPessoaEditados(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClientePage = lifetimeScope.Resolve<IEdicaoDeClientePageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeClientePage.VerificarDadosDaPessoaEditados();
        }

        public void Gravar() => 
            DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoGravar);

        public void FecharJanelaCadastroDeClienteComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeClienteModel.ElementoTelaCadastroCliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
