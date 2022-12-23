using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.ClienteSimplificado.Page
{
    public class ClienteSimplificadoBasePage: PageObjectModel
    {
        public ClienteSimplificadoBasePage(DriverService driver) : base(driver)
        {
        }

        private void ClicarNaOpcaoDoMenu() =>
            AcessarOpcaoMenu(CadastroDeClienteSimplificadoModel.BotaoMenuCadastro);

        private void ClicarNaOpcaoDoSubMenu() =>
            AcessarOpcaoSubMenu(CadastroDeClienteSimplificadoModel.BotaoSubMenu);

        private void AbrirTelaDeClienteSimplificado() =>
            ClicarBotao(CadastroDeClienteSimplificadoModel.ElementoDeAtalhoDeClienteSimplificado);
    }
}
