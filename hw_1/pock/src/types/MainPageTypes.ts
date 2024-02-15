export type PokemonType = {
  name: string;
  id: string;
  url: string;
  img: string;
}

export type PokemonResponseType = {
  count: number;
  results: PokemonType[];
}

export type PokemonDataResponseType = {
  id: string;
  name: string;
  sprites: {
    front_default: string;
  }
}