using System;

namespace Pokedex_Xam.Model
{

    public partial class PokemonList
    {
        public long Count { get; set; }
        public Uri Next { get; set; }
        public object Previous { get; set; }
        public Pokemon[] Results { get; set; }
    }

    public partial class Pokemon
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}