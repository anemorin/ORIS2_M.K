export type PokemonResponseType = {
  id: string;
  name: string;
  imageUrl: string;
  types: PokemonAbilityType[];
}

export type PokemonsResponseType = {
  totalCount: number;
  pokemons: PokemonResponseType[];
}

type PokemonAbilityType = {
  slot: number;
  type: {
    name: string;
    url: string;
  }
}

type StatsType = {
  base_stat: number;
  stat: {
    name: string;
  }
}

type MovesType = {
  move: {
    name: string;
  }
}

type AbilityType = {
  ability: {
    name: string;
  }
}

export type PokemonType = {
  id: string;
  name: string;
  sprites: {
    front_default: string;
    other: {
      home: {
        front_default: string;
      }
    }
  }
  stats: StatsType[];
  types: PokemonAbilityType[];
  height: number;
  weight: number;
  moves: MovesType[];
  abilities: AbilityType[];
}