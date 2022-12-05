using System;
using System.Collections.Generic;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.ExceptionPessoa;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor
{
    public class CadastroDeFornecedorPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDeFornecedor;

        public CadastroDeFornecedorPage(DriverService driver, Dictionary<string, string> dadosDeFornecedor) :
            base(driver) =>
            _dadosDeFornecedor = dadosDeFornecedor;

        public bool ClicarNaOpcaoDoMenu()
        {
            try
            {
                AcessarOpcaoMenu(CadastroDeFornecedorModel.BotaoMenu);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool ClicarNaOpcaoDoSubMenu()
        {
            try
            {
                AcessarOpcaoSubMenu(CadastroDeFornecedorModel.BotaoSubMenu);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool ClicarBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeFornecedorModel.BotaoNovo);
                return true;
            }
            catch (Exception exception)
            {
                throw new ErroAoConcluirAcaoDoCadastroDePessoaException($"{exception}");
            }
        }

        public bool ClicarBotaoPesquisar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeFornecedorModel.BotaoPesquisar);
                return true;
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
                DriverService.DigitarNoCampoEnterId(CadastroDeFornecedorModel.ElementoCep, _dadosDeFornecedor["Cep"]);
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
                DriverService.DigitarNoCampoEnterId(CadastroDeFornecedorModel.ElementoDataDeNascimento,
                    _dadosDeFornecedor["DataNascimento"]);
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
    }
}
