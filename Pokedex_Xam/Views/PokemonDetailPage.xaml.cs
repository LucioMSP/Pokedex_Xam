using System;
using System.Collections.Generic;
using Pokedex_Xam.ViewModels;
using Xamarin.Forms;

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
