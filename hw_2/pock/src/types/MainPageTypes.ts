export type PokemonResponseType = {
  name: string;
  url: string;
}

export type PokemonsResponseType = {
  count: number;
  results: PokemonResponseType[];
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