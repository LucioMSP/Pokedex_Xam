using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Pokedex_Xam.ViewModels
{
    public class PokemonDetailViewModel : INotifyPropertyChanged
    {
        HttpClient client;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Model.Types> _types;
        private ObservableCollection<Model.Stats> _stats;
        private ObservableCollection<Model.Moves> _moves;
        private string _url;
        private string _name;
        private bool _isShowContentStats;
        private bool _isShowContentMoves;

        public bool IsShowContentMoves { get { return _isShowContentMoves; } set { SetProperty(ref _isShowContentMoves, value); } }

        public bool IsShowContentStats { get { return _isShowContentStats; } set { SetProperty(ref _isShowContentStats, value); } }

        public ICommand StatsCommand => new Command( () =>
        {
            OnChangedShowContent(false);
        });


        public ICommand MovesCommand => new Command(() =>
        {
            OnChangedShowContent(true);
        });


        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

        public string Url { get { return _url; } set { SetProperty(ref _url, value); } }

        public ObservableCollection<Model.Types> Types { get { return _types; } set { SetProperty(ref _types, value); } }

        public ObservableCollection<Model.Stats> Stats { get { return _stats; } set { SetProperty(ref _stats, value); } }

        public ObservableCollection<Model.Moves> Moves { get { return _moves; } set { SetProperty(ref _moves, value); } }

        public PokemonDetailViewModel(Model.Pokemon pokemon)
        {
            GetData(pokemon);


        }

        public async void GetData(Model.Pokemon pokemon)
        {
            client = new HttpClient();
            var request = await client.GetAsync(pokemon.Url);
            string response = request.Content.ReadAsStringAsync().Result;
            var pokemonInfo = JsonConvert.DeserializeObject<Model.PokemonInfo>(response);
            Types = new ObservableCollection<Model.Types>();
            Stats = new ObservableCollection<Model.Stats>();
            Moves = new ObservableCollection<Model.Moves>();
            Name = pokemonInfo.Name;
            Url = pokemonInfo.Sprites.Other.Official_artwork.Front_default;
            IsShowContentStats = true;
            
            foreach (var item in pokemonInfo.Types)
            {
                Types.Add(item);
            }

            foreach (var item in pokemonInfo.Stats)
            {
                Decimal attack =  Convert.ToDecimal(item.Base_stat) / (Decimal)100;
                Decimal decimalAtack = Math.Round(attack, 1);

                item.Base_stat_Porcent = decimalAtack.ToString("N2"); 
                Stats.Add(item);
            }

            foreach (var item in pokemonInfo.Moves)
            {
                Moves.Add(item);
            }
            
        }


        public  void OnChangedShowContent(bool isMoves)
        {
            IsShowContentMoves = isMoves;
            IsShowContentStats = !isMoves;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
