using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;
using OpenQA.Selenium;
using SigecomTestesUI.Config;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.CadastroDeFornecedor.Page
{
    public class CadastroDeFornecedorFisicoPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor;

        public CadastroDeFornecedorFisicoPage(DriverService driver, Dictionary<string, string> dadosDeFornecedor) :
            base(driver) =>
            _dadosDeFornecedor = dadosDeFornecedor;

        private void ClicarNaOpcaoDoMenu()
        {
            try
            {
                AcessarOpcaoMenu(CadastroDeFornecedorModel.BotaoMenu);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void ClicarNaOpcaoDoSubMenu()
        {
            try
            {
                AcessarOpcaoSubMenu(CadastroDeFornecedorModel.BotaoSubMenu);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void ClicarBotaoNovo()
        {
            try
            {
                ClicarBotao(CadastroDeFornecedorModel.BotaoNovo);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        private void ClicarBotaoPesquisar()
        {
            try
            {
                ClicarBotao(CadastroDeFornecedorModel.BotaoPesquisar);
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoTipoPessoa);
            return valorTipoPessoa == "FÍSICA";
        }

        public bool PreencherCamposSimples()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNome, _dadosDeFornecedor["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoCpf, _dadosDeFornecedor["Cpf"]);
                DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeFornecedorModel.ElementoCep, _dadosDeFornecedor["Cep"], Keys.Enter);
                EsperarAcaoEmSegundos(3);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNumero, _dadosDeFornecedor["Numero"]);
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
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoRg, _dadosDeFornecedor["Rg"]);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoApelido,
                    _dadosDeFornecedor["Apelido"]);
                DriverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeFornecedorModel.ElementoDataDeNascimento,
                    _dadosDeFornecedor["DataNascimento"], Keys.Enter);
                DriverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoSexo, 1);
                DriverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoEstadoCivil, 1);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoComplemento,
                    _dadosDeFornecedor["Complemento"]);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoObservacao,
                    _dadosDeFornecedor["Observacao"]);
                DriverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoTipoContato, 3);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoContatoDoCliente,
                    _dadosDeFornecedor["ContatoPrimario"]);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoObsContatoDoCliente,
                    _dadosDeFornecedor["ObservacaoContatoPrimario"]);
                DriverService.ClicarBotaoId(CadastroDeFornecedorModel.BotaoContato);
                EsperarAcaoEmSegundos(2);
                DriverService.SelecionarItemComboBox(CadastroDeFornecedorModel.ElementoTipoContato, 1);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoContatoDoCliente,
                    _dadosDeFornecedor["ContatoSecundario"]);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoObsContatoDoCliente,
                    _dadosDeFornecedor["ObservacaoContatoSecundario"]);
                DriverService.ClicarBotaoId(CadastroDeFornecedorModel.BotaoContato);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool GravarCadastro()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeFornecedorModel.BotaoGravar);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool FecharJanelaCadastroFornecedorComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeFornecedorModel.TelaCadastroFornecedor);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public void AcessarTelaDeCadastroDeFornecedorEPesquisar()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoPesquisar();
            VerificarTipoPessoa();
        }

        public void AcessarTelaDeCadastroDeFornecedor()
        {
            ClicarNaOpcaoDoMenu();
            ClicarNaOpcaoDoSubMenu();
            ClicarBotaoNovo();
            VerificarTipoPessoa();
        }

        public void PesquisarFornecedorGravado(ILifetimeScope beginLifetimeScope)
        {
            ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("fornecedor", _dadosDeFornecedor["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDeFornecedor["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("fornecedor");
            FecharJanelaCadastroFornecedorComEsc();
        }
    }
}
