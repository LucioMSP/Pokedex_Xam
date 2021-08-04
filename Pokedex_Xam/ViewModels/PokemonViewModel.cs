using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Pokedex_Xam.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Pokedex_Xam.ViewModels
{
    public class PokemonViewModel
    {
        public ObservableCollection<Pokemon> pokemonList { get; set; }

        HttpClient client;

        public PokemonViewModel()
        {
            pokemonList = new ObservableCollection<Pokemon>();
            initalizeListView();
        }

        public ICommand ItemTapped => new Command(async (pokemon) =>
        {
            var pokemonSeleccionado = pokemon as Pokemon;
            await App.Current.MainPage.Navigation.PushAsync(new Views.PokemonDetailPage(pokemonSeleccionado));
        });

        public async void initalizeListView()
        {
            client = new HttpClient();
            var request = await client.GetAsync("https://pokeapi.co/api/v2/pokemon?limit=150");
            string response = request.Content.ReadAsStringAsync().Result;

            var pokemonlistfull = JsonConvert.DeserializeObject<PokemonList>(response);

            foreach (var item in pokemonlistfull.Results)
            {
                pokemonList.Add(item);
            }
        }
    }
}