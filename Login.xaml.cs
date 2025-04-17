namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
		try 
		{
            //Classe DadosUsuario por fins de exemplo e preguiça
            List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "NomeTeste",
					Senha = "123456"
				},
				new DadosUsuario()
				{
                    Usuario = "NomeTeste2",
                    Senha = "654321"
                }
			};

			// Le o entry do XAML
			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			// LINQ teste
			if(lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario 
										&& dados_digitados.Senha == i.Senha))) 
			//pra cada (i)item da lista verifica se oq foi digitado como usuario e senha existe algum (i)item na lista igual
            {
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();
            }
			else
			{
				throw new Exception("Usuário ou senha inválidos.");
            }

        }
		catch(Exception ex) 
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
    }
}