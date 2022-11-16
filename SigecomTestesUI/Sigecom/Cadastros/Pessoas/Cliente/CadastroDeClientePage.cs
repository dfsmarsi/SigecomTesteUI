using System;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente
{
    public class CadastroDeClientePage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dadosDoCliente;

        public CadastroDeClientePage(DriverService driver, Dictionary<string, string> dadosDoCliente) : base(driver) => 
            _dadosDoCliente = dadosDoCliente;

        public bool ClicarNaOpcaoDoMenu() => 
            AcessarOpcaoMenu(CadastroDeCienteModel.BotaoMenu);

        public bool ClicarNaOpcaoDoSubMenu() => 
            AcessarOpcaoSubMenu(CadastroDeCienteModel.BotaoSubMenu);

        public bool ClicarBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeCienteModel.BotaoNovo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClicarBotaoPesquisar()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeCienteModel.BotaoPesquisar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeCienteModel.ElementoTipoPessoa);
            return valorTipoPessoa == "FÍSICA";
        }

        public bool PreencherCampos()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeCienteModel.ElementoNome, _dadosDoCliente["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeCienteModel.ElementoCpf, _dadosDoCliente["Cpf"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeCienteModel.ElementoCep, _dadosDoCliente["Cep"]);
                EsperarAcaoEmSegundos(5);
                DriverService.DigitarNoCampoId(CadastroDeCienteModel.ElementoNumero, _dadosDoCliente["Numero"]);
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
                DriverService.ClicarBotaoName(CadastroDeCienteModel.BotaoGravar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeCienteModel.ElementoTelaCadastroCliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
