using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente
{
    public class CadastroDeClienteJuridicoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDoCliente;

        public CadastroDeClienteJuridicoPage(DriverService driver, Dictionary<string, string> dadosDoCliente) : base(driver) =>
            _dadosDoCliente = dadosDoCliente;

        private void ClicarNaOpcaoDoMenu() => 
            AcessarOpcaoMenu(CadastroDeClienteModel.BotaoMenu);

        private void ClicarNaOpcaoDoSubMenu() => 
            AcessarOpcaoSubMenu(CadastroDeClienteModel.BotaoSubMenu);

        private void ClicarBotaoNovo() =>
            ClicarBotaoNovo(CadastroDeClienteModel.BotaoNovo);

        private void ClicarBotaoPesquisar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoPesquisar);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeClienteModel.ElementoTipoPessoa);
            return valorTipoPessoa.Equals("JURÍDICA");
        }

        public bool PreencherCamposSimples()
        {
            try
            {
                DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoPessoa, 1);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNome, _dadosDoCliente["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoCpf, _dadosDoCliente["Cnpj"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeClienteModel.ElementoCep, _dadosDoCliente["Cep"]);
                EsperarAcaoEmSegundos(3);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoNumero, _dadosDoCliente["Numero"]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PreencherCamposCompleto()
        {
            try
            {
                PreencherCamposSimples();
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoRg, _dadosDoCliente["Ie"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoInscricaoSuframa, _dadosDoCliente["Suframa"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoApelido, _dadosDoCliente["NomeFantasia"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoComplemento, _dadosDoCliente["Complemento"]);
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObservacao, _dadosDoCliente["Observacao"]);
                CadastrarContatosDoCliente();
                DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoAvisoDeVenda, _dadosDoCliente["AvisoDeVenda"]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CadastrarContatosDoCliente()
        {
            DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoContato, 3);
            DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoContatoDoCliente, _dadosDoCliente["ContatoPrimario"]);
            DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObsContatoDoCliente, _dadosDoCliente["ObservacaoContatoPrimario"]);
            DriverService.ClicarBotaoId(CadastroDeClienteModel.BotaoContato);
            EsperarAcaoEmSegundos(2);
            DriverService.SelecionarItemComboBox(CadastroDeClienteModel.ElementoTipoContato, 1);
            DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoContatoDoCliente, _dadosDoCliente["ContatoSecundario"]);
            DriverService.DigitarNoCampoId(CadastroDeClienteModel.ElementoObsContatoDoCliente, _dadosDoCliente["ObservacaoContatoSecundario"]); 
            DriverService.ClicarBotaoId(CadastroDeClienteModel.BotaoContato);
        }

        public bool GravarCadastro()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeClienteModel.BotaoGravar);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeClienteModel.ElementoTelaCadastroCliente);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public void AcessarTelaDeCadastroDeCliente()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoNovo();
            VerificarTipoPessoa();
        }

        public void PesquisarClienteGravado(ILifetimeScope beginLifetimeScope)
        {
            ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("cliente", _dadosDoCliente["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDoCliente["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("cliente");
            FecharJanelaComEsc();
        }
    }
}
