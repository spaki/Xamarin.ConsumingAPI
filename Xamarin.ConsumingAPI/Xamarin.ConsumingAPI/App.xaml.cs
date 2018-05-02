using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xamarin.ConsumingAPI.Model;
using Xamarin.Forms;

namespace Xamarin.ConsumingAPI
{
    public partial class App : Application
	{
        private static HttpClient client = new HttpClient();
        private Entry textBusca = new Entry();
        private ListView lista = new ListView();

        public App ()
		{
			InitializeComponent();

            //MainPage = new Xamarin.ConsumingAPI.MainPage();

            textBusca = new Entry();
            textBusca.Placeholder = "Informe o valor para a pesquisa";

            var botaoPesquisa = new Button();
            botaoPesquisa.Text = "Pesquisar";
            botaoPesquisa.Clicked += BotaoPesquisa_Clicked;

            lista = new ListView();

            var layout = new StackLayout();
            layout.Padding = 20;
            layout.Spacing = 20;
            layout.Children.Add(textBusca);
            layout.Children.Add(botaoPesquisa);
            layout.Children.Add(lista);

            var pagina = new ContentPage();
            pagina.Content = layout;

            MainPage = pagina;
		}

        private async void BotaoPesquisa_Clicked(object sender, EventArgs e)
        {
            var url = "https://swapi.co/api/starships/?search=" + WebUtility.UrlEncode(textBusca.Text) + "&format=json";
            var response = await client.GetStringAsync(url);
            var items = JsonConvert.DeserializeObject<ApiResult>(response);
            lista.ItemsSource = items?.Results.Select(item => $"{item.Name}/{item.Starship_class}/{item.Manufacturer}");
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
