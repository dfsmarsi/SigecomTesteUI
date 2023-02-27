using System;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Enum;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Pedido.LancarPedidos.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page
{
    public class ClienteSimplificadoBasePage: PageObjectModel
    {
        public ClienteSimplificadoBasePage(DriverService driver) : base(driver) { }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PedidoModel.BotaoSubMenu);

        private void AbrirTelaDeClienteSimplificado()
        {
            ClicarBotaoName(PedidoModel.BotaoAtalhosVenda);
            ClicarBotaoName(PedidoModel.BotaoClienteSimplificado);
        }

        private void VerificarCamposDoClienteCompletoCarregado()
        {
            try
            {
                Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeClienteSimplificadoModel.ElementoEnderecoDoCliente), CadastroDeClienteSimplificadoFisicoCompletoModel.EnderecoDoCliente);
                Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeClienteSimplificadoModel.ElementoBairroDoCliente), CadastroDeClienteSimplificadoFisicoCompletoModel.BairroDoCliente);
                Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeClienteSimplificadoModel.ElementoCidadeDoCliente), CadastroDeClienteSimplificadoFisicoCompletoModel.CidadeDoCliente);
                Assert.AreEqual(DriverService.ObterValorElementoId(CadastroDeClienteSimplificadoModel.ElementoEstadoDoCliente), CadastroDeClienteSimplificadoFisicoCompletoModel.EstadoDoCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void PreencherCamposDoCliente(TipoDeClienteSimplificado tipoDeClienteSimplificado)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IClienteSimplificadoPageFactory>().Fabricar(DriverService, tipoDeClienteSimplificado).PreencherCamposDoCliente();
        }

        private void GravarClienteSimplificado() => 
            ClicarBotaoName(CadastroDeClienteSimplificadoModel.BotaoDoConfirmar);

        private void FecharTelaDeVendaComEsc() =>
            DriverService.FecharJanelaComEsc(PedidoModel.ElementoTelaDeVenda);

        public void RealizarFluxoDeCadastroDeClienteSimplificado(TipoDeClienteSimplificado tipoDeClienteSimplificado)
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            AbrirTelaDeClienteSimplificado();
            PreencherCamposDoCliente(tipoDeClienteSimplificado);
            
            if (tipoDeClienteSimplificado.Equals(TipoDeClienteSimplificado.FisicoCompleto))
                VerificarCamposDoClienteCompletoCarregado();

            GravarClienteSimplificado();
            FecharTelaDeVendaComEsc();
        }
    }
}
