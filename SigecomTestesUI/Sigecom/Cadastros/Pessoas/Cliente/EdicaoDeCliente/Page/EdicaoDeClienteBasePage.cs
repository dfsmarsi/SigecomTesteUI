using System;
using Autofac;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;

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
            ClicarBotaoNovo();
        }
        public void VerificarInformacoesDoCliente()
        {
            using var lifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var edicaoDeClienteFisicoSimplesPage = lifetimeScope.Resolve<Func<DriverService, EdicaoDeClienteFisicoSimplesPage>>()(DriverService);
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
