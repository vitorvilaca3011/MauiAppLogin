namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string? usuario_logado = null;

            // manda o usuario pra pagina de login por padrao
            MainPage = new Login();

            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                // se o usuario tiver feito o login, ou seja o usuario ja logou 1 vez ele ja manda pra protegida
                if (usuario_logado != null)
                {
                    MainPage = new Protegida();
                }

            });
        }
        
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 700;

            return window;
        }

    } // Fecha classe
} // Fecha namespace