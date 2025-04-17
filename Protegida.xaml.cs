namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
            usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_boasvindas.Text = $"Bem Vindo(a) {usuario_logado}";
        });
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // confirmaçao de saída do app, se sim, remove o usuario logado do SecureStorage e volta pra tela de login
        bool confirmacao = await DisplayAlert("Tem Certeza?", "Sair do app?", "Sim", "Não"); 

		if (confirmacao) 
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();	
        }
		//

    }
}