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
  types: PokemonAbilityType[];
}