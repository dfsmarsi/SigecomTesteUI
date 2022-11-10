using System;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente
{
    public class CadastroDeClientePage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dados;

        public CadastroDeClientePage(DriverService driver, Dictionary<string, string> dados) : base(driver) => 
            _dados = dados;

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
                DriverService.DigitarNoCampoId(CadastroDeCienteModel.ElementoNome, _dados["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeCienteModel.ElementoCpf, _dados["Cpf"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeCienteModel.ElementoCep, _dados["Cep"]);
                EsperarAcaoEmSegundos(5);
                DriverService.DigitarNoCampoId(CadastroDeCienteModel.ElementoNumero, _dados["Numero"]);
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
