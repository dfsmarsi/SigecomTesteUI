using System;
using System.Collections.Generic;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Fornecedor
{
    public class CadastroDeFornecedorPage : PageObjectModel
    {
        private readonly Dictionary<string, string> _dados;

        public CadastroDeFornecedorPage(DriverService driver, Dictionary<string, string> dados) : base(driver) => 
            _dados = dados;

        public bool ClicarNaOpcaoDoMenu()
        {
            try
            {
                AcessarOpcaoMenu(CadastroDeFornecedorModel.BotaoMenu);
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
                AcessarOpcaoSubMenu(CadastroDeFornecedorModel.BotaoSubMenu);
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
                DriverService.ClicarBotaoName(CadastroDeFornecedorModel.BotaoNovo);
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
                DriverService.ClicarBotaoName(CadastroDeFornecedorModel.BotaoPesquisar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarTipoPessoa()
        {
            var valorTipoPessoa = DriverService.ObterValorElementoId(CadastroDeFornecedorModel.ElementoTipoPessoa);
            return valorTipoPessoa == "FÍSICA";
        }

        public bool PreencherCampos()
        {
            try
            {
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNome, _dados["Nome"]);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoCpf, _dados["Cpf"]);
                DriverService.DigitarNoCampoEnterId(CadastroDeFornecedorModel.ElementoCep, _dados["Cep"]);
                EsperarAcaoEmSegundos(5);
                DriverService.DigitarNoCampoId(CadastroDeFornecedorModel.ElementoNumero, _dados["Numero"]);
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
            catch (Exception)
            {
                return false;
            }
        }

        public bool FecharJanelaCadastroFornecedorComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(CadastroDeFornecedorModel.TelaCadastroFornecedor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
