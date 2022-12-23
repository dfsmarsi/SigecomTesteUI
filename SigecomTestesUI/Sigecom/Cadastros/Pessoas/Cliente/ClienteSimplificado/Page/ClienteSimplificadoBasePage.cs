using System;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Enum;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page.Interfaces;
using SigecomTestesUI.Sigecom.Vendas.Pedido.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page
{
    public class ClienteSimplificadoBasePage: PageObjectModel
    {
        public ClienteSimplificadoBasePage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(PedidoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(PedidoModel.BotaoSubMenu);

        private void AbrirTelaDeClienteSimplificado() =>
            ClicarBotao(CadastroDeClienteSimplificadoModel.ElementoDeAtalhoDeClienteSimplificado);

        public void VerificarCamposDoClienteCompletoCarregado()
        {
            try
            {
                Assert.AreEqual(DriverService.EncontrarElementoName(CadastroDeClienteSimplificadoModel.ElementoEnderecoDoCliente), CadastroDeClienteSimplificadoFisicoCompletoModel.EnderecoDoCliente);
                Assert.AreEqual(DriverService.EncontrarElementoName(CadastroDeClienteSimplificadoModel.ElementoBairroDoCliente), CadastroDeClienteSimplificadoFisicoCompletoModel.BairroDoCliente);
                Assert.AreEqual(DriverService.EncontrarElementoName(CadastroDeClienteSimplificadoModel.ElementoCidadeDoCliente), CadastroDeClienteSimplificadoFisicoCompletoModel.CidadeDoCliente);
                Assert.AreEqual(DriverService.EncontrarElementoName(CadastroDeClienteSimplificadoModel.ElementoEstadoDoCliente), CadastroDeClienteSimplificadoFisicoCompletoModel.EstadoDoCliente);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public void PreencherCamposDoCliente(TipoDeClienteSimplificado tipoDeClienteSimplificado)
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            beginLifetimeScope.Resolve<IClienteSimplificadoPageFactory>().Fabricar(DriverService, tipoDeClienteSimplificado);
        }
    }
}
