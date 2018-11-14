using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xamarin.ConsumingAPI.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xamarin.ConsumingAPI
{
    public partial class App : Application
    {
        private static HttpClient client = new HttpClient();
        private Label labelTitle = new Label();
        private Button botaoPesquisa = new Button();
        private Entry textBusca = new Entry();
        private ListView lista = new ListView();
        private ContentPage pagina = new ContentPage();

        public App()
        {
            InitializeComponent();

            labelTitle.Text = "Star Wars Ships";
            labelTitle.VerticalTextAlignment = TextAlignment.Center;
            labelTitle.FontSize = 28;

            botaoPesquisa.Text = "Pesquisar";
            botaoPesquisa.Clicked += BotaoPesquisa_Clicked;

            textBusca.Placeholder = "Informe o valor para a pesquisa";

            var layout = new StackLayout();
            layout.Padding = 20;
            layout.Spacing = 20;
            layout.Children.Add(labelTitle);
            layout.Children.Add(textBusca);
            layout.Children.Add(botaoPesquisa);
            layout.Children.Add(lista);

            pagina.Content = layout;

            MainPage = pagina;
        }

        private async void BotaoPesquisa_Clicked(object sender, EventArgs e)
        {
            try
            {
                var url = "https://swapi.co/api/starships/?search=" + WebUtility.UrlEncode(textBusca.Text) + "&format=json";
                var response = await client.GetStringAsync(url);
                var apiResult = JsonConvert.DeserializeObject<ApiResult>(response);
                var items = apiResult?.Results.Select(item => $"{item.Name}/{item.Manufacturer}/{item.Starship_class}").ToList();
                lista.ItemsSource = items;
            }
            catch (Exception ex)
            {
                await pagina.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
