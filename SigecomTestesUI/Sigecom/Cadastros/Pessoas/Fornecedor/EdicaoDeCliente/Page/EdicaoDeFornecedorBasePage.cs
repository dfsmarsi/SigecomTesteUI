using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeCliente.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeCliente.Page
{
    public class EdicaoDeFornecedorBasePage : PageObjectModel
    {
        public EdicaoDeFornecedorBasePage(DriverService driver) : base(driver) { }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeFornecedorModel.BotaoMenu);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeFornecedorModel.BotaoSubMenu);

        public void ClicarNoAtalhoDePesquisar() =>
            DriverService.AbrirPesquisaComF9(CadastroDeFornecedorModel.BotaoPesquisar);

        public void AbrirTelaDeCadastroDeFornecedor()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
        }

        public void PesquisarFornecedorQueSeraEditado(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeFornecedorPage.PesquisarFornecedorQueSeraEditado(this);
        }

        public void VerificarInformacoesDoFornecedor(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeFornecedorPage.VerificarDadosDaPessoa();
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeFornecedorPage.PreencherAsInformacoesDaPessoasNaEdicao();
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
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            edicaoDeFornecedorPage.FluxoDePesquisaDaPessoaEditado(this, pesquisaDePessoaPage);
        }

        public void VerificarDadosDaPessoaEditados(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeFornecedorPage.VerificarDadosDaPessoaEditados();
        }

        public void Gravar() =>
            DriverService.ClicarBotaoName(CadastroDeFornecedorModel.BotaoGravar);

        public void FecharJanelaCadastroDeFornecedorComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeFornecedorModel.TelaCadastroFornecedor);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDaEdicaoDePessoaException($"{exception}");
            }
        }
    }
}
