using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Model;
using SigecomTestesUI.Sigecom.Vendas.Orcamento.LancarOrcamento.Model;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Vendas.Orcamento.ConsultaDeOrcamento.Page
{
    public class EditarNaConsultaDeOrcamentoPage :PageObjectModel
    {
        public EditarNaConsultaDeOrcamentoPage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
           AcessarOpcaoMenu(ConsultaDeOrcamentoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(ConsultaDeOrcamentoModel.BotaoSubMenu);

        public void RealizarFluxoDeEditarNaConsultaDoOrcamento()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            RealizarOFluxoDeGerarOrcamentoNaConsulta();
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDaAlterarOrcamento);
            DriverService.EditarItensNaGridComDuploClickComTab(OrcamentoModel.CampoDaGridDeQuantidadeDoProduto, LancarItensNoOrcamentoModel.QuantidadeDeProduto);
            Assert.AreEqual(DriverService.PegarValorDaColunaDaGrid(OrcamentoModel.CampoDaGridDeTotalDoProduto), LancarItensNoOrcamentoModel.ValorTotalSemDesconto);
            AvancarNoOrcamento();
            AvancarNoOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
            FecharTelaDoOrcamentoComEsc();
            DriverService.FecharJanelaComEsc(OrcamentoModel.ElementoTelaDeOrcamento);
        }

        private void RealizarOFluxoDeGerarOrcamentoNaConsulta()
        {
            ClicarBotaoName(ConsultaDeOrcamentoModel.BotaoDaNovaOrcamento);
            LancarProduto(LancarItensNoOrcamentoModel.PesquisarItemId);
            AvancarNoOrcamento();
            AvancarNoOrcamento();
            DriverService.RealizarSelecaoDaAcao(OrcamentoModel.AcoesDoOrcamento, 2);
        }

        private void LancarProduto(string textoDePesquisa)
            => DriverService.DigitarNoCampoComTeclaDeAtalhoId(OrcamentoModel.ElementoPesquisaDeProduto, textoDePesquisa, Keys.Enter);

        private void AvancarNoOrcamento()
            => ClicarBotaoName(OrcamentoModel.ElementoNameDoAvancar);

        private void FecharTelaDoOrcamentoComEsc() =>
            DriverService.FecharJanelaComEsc(ConsultaDeOrcamentoModel.ElementoTelaDoOrcamento);
    }
}
