using System;
using System.Collections.Generic;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador
{
    public class CadastroDeColaboradorPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dados;

        public CadastroDeColaboradorPage(DriverService driver, Dictionary<string, string> dados) : base(driver) => 
            _dados = dados;

        public bool ClicarNaOpcaoDoMenu()
        {
            try
            {
                AcessarOpcaoMenu(CadastroDeColaboradorModel.BotaoMenu);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClicarNaOpcaoDoSubMenu()
        {
            try
            {
                AcessarOpcaoSubMenu(CadastroDeColaboradorModel.BotaoSubMenu);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ClicarBotaoNovo()
        {
            try
            {
                DriverService.ClicarBotaoName(CadastroDeColaboradorModel.BotaoNovo);
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
                DriverService.ClicarBotaoName(CadastroDeColaboradorModel.BotaoPesquisar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoTipoPessoa);
            return valorTipoPessoa == "FÍSICA";
        }

        public bool PreencherCampos()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNome, _dados["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoCpf, _dados["Cpf"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeColaboradorModel.ElementoCep, _dados["Cep"]);
                EsperarAcaoEmSegundos(5);
                DriverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNumero, _dados["Numero"]);
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
                DriverService.ClicarBotaoName(CadastroDeColaboradorModel.BotaoGravar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool FecharJanelaCadastroColaboradorComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeColaboradorModel.TelaCadastroColaborador);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
