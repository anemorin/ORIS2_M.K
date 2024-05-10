export type PokemonResponseType = {
  pokemon: PokemonType; 
  types: string[];
}

export type PokemonsResponseType = {
  pokemons: PokemonResponseType[];
}

type PokemonAbilityType = {
  id: string;
  slot: number;
  name: string;
}

type StatsType = {
  id: string; 
  name: string; 
  value: number;
}

type AbilityType = {
  id: string; 
  name: string;
}

export type PokemonType = {
  id: string;
  name: string;
  imgUrl: string;
  order: string;
  stat: StatsType[];
  types: PokemonAbilityType[];
  moves: string[];
  abilities: AbilityType[];
  typesList: string[];
  breeding: {
    id: string,
    weight: number,
    height: number,
    pokemonId: string;
  }
}
