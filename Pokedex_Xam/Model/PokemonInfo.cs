using Newtonsoft.Json;

namespace Pokedex_Xam.Model
{
    public class PokemonInfo
    {
        public string Height  {get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public AbilityDetail[] Abilities { get; set; }
        public Sprites Sprites { get; set; }
        public Types[] Types { get; set; }
        public Stats[] Stats { get; set; }
        public Moves[] Moves { get; set; }
    }

    public partial class Moves
    {
        public Move Move { get; set; }
    }

    public partial class Stats
    {
        public Stat Stat { get; set; }
        public string Base_stat { get; set; }
        public string Base_stat_Porcent { get; set; }
    }

    public partial class AbilityDetail
    {
        public Ability Ability { get; set; }
    }

    public partial class Sprites
    {
        public Other Other { get; set; }
    }

    public partial class Other
    {
        public Dream_World Dream_world { get; set; }
        [JsonProperty("official-artwork")]
        public Official_Artwork Official_artwork { get; set; }
    }

    public partial class Types
    {
        public TypePokemon Type { get; set; }
    }

    public partial class Ability
    {
        public string Name { get; set; }
    }
   
    public partial class Dream_World
    {
        public string Front_default { get; set; }
    }

    public partial class Official_Artwork
    {
        public string Front_default { get; set; }
    }

    public partial class TypePokemon
    {
        public string Name { get; set; }
    }

    public partial class Stat
    {
        public string Name { get; set; }
    }

    public partial class Move
    {
        public string Name { get; set; }
    }
}