using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page
{
    public class EdicaoDeColaboradorBasePage : PageObjectModel
    {
        public EdicaoDeColaboradorBasePage(DriverService driver) : base(driver) { }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeColaboradorModel.BotaoMenu);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeColaboradorModel.BotaoSubMenu);

        public void ClicarNoAtalhoDePesquisar() =>
            DriverService.AbrirPesquisaComF9(CadastroDeColaboradorModel.BotaoPesquisar);

        public void AbrirTelaDeCadastroDeColaborador()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
        }

        public void PesquisarColaboradorQueSeraEditado(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeColaboradorPage = lifetimeScope.Resolve<IEdicaoDeColaboradorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeColaboradorPage.PesquisarColaboradorQueSeraEditado(this);
        }

        public void VerificarInformacoesDoColaborador(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeColaboradorPage = lifetimeScope.Resolve<IEdicaoDeColaboradorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeColaboradorPage.VerificarDadosDaPessoa();
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeColaboradorPage = lifetimeScope.Resolve<IEdicaoDeColaboradorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeColaboradorPage.PreencherAsInformacoesDaPessoasNaEdicao();
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
            var edicaoDeColaboradorPage = lifetimeScope.Resolve<IEdicaoDeColaboradorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            edicaoDeColaboradorPage.FluxoDePesquisaDaPessoaEditado(this, pesquisaDePessoaPage);
        }

        public void VerificarDadosDaPessoaEditados(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeColaboradorPage = lifetimeScope.Resolve<IEdicaoDeColaboradorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeColaboradorPage.VerificarDadosDaPessoaEditados();
        }

        public void Gravar() =>
            DriverService.ClicarBotaoName(CadastroDeColaboradorModel.BotaoGravar);

        public void FecharJanelaCadastroDeColaboradorComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeColaboradorModel.TelaCadastroColaborador);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDePessoaException($"{exception}");
            }
        }
    }
}
