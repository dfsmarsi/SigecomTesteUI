using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.EdicaoDeFornecedor.Page
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

        public void RealizarFluxoDaEdicaoDeFornecedor(ClassificacaoDePessoa classificacaoDePessoa)
        {
            // Arange
            PesquisarFornecedorQueSeraEditado(classificacaoDePessoa);

            // Act
            VerificarInformacoesDoFornecedor(classificacaoDePessoa);
            PreencherAsInformacoesDaPessoasNaEdicao(classificacaoDePessoa);
            Gravar();

            // Assert
            FluxoDePesquisaDaPessoaEditado(classificacaoDePessoa);
            VerificarDadosDaPessoaEditados(classificacaoDePessoa);
            FecharJanelaCadastroDeFornecedorComEsc();
        }

        private void PesquisarFornecedorQueSeraEditado(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeFornecedorPage.PesquisarFornecedorQueSeraEditado(this);
        }

        private void VerificarInformacoesDoFornecedor(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeFornecedorPage.VerificarDadosDaPessoa();
        }

        private void PreencherAsInformacoesDaPessoasNaEdicao(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeFornecedorPage.PreencherAsInformacoesDaPessoasNaEdicao();
        }

        private void Gravar() =>
            DriverService.ClicarBotaoName(CadastroDeFornecedorModel.BotaoGravar);

        internal void RetornarPesquisaDePessoa(out PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
        }

        private void FluxoDePesquisaDaPessoaEditado(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            edicaoDeFornecedorPage.FluxoDePesquisaDaPessoaEditado(this, pesquisaDePessoaPage);
        }

        private void VerificarDadosDaPessoaEditados(ClassificacaoDePessoa classificacaoDePessoa)
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeFornecedorPage = lifetimeScope.Resolve<IEdicaoDeFornecedorPageFactory>().Fabricar(DriverService, classificacaoDePessoa);
            edicaoDeFornecedorPage.VerificarDadosDaPessoaEditados();
        }

        private void FecharJanelaCadastroDeFornecedorComEsc()
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
