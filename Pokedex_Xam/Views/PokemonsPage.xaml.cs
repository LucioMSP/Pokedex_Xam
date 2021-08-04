using Xamarin.Forms;
using Pokedex_Xam.ViewModels;

namespace Pokedex_Xam.Views
{
    public partial class PokemonsPage : ContentPage
    {
        public PokemonsPage()
        {
            InitializeComponent();
            BindingContext = new PokemonViewModel();
        }
    }
}