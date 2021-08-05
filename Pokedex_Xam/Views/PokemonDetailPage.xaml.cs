using Xamarin.Forms;
using Pokedex_Xam.ViewModels;

namespace Pokedex_Xam.Views
{
    public partial class PokemonDetailPage : ContentPage
    {
        public PokemonDetailPage(Model.Pokemon pokemon)
        {
            InitializeComponent();
            BindingContext = new PokemonDetailViewModel(pokemon);
        }
    }
}