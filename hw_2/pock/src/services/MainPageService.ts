import axios from "axios";
import { PokemonType, PokemonsResponseType } from "../types/MainPageTypes";

class MainPageService {
  static async fetchPokemons(limit: number) {
    try {
      const response = await axios.get<PokemonsResponseType>(`https://pokeapi.co/api/v2/pokemon/?limit=${limit}`, {
        method: "GET",
      });

      if (response.status === 200) {
        return response.data;
      }
    }
    catch (error) {
      console.warn(error)
      alert('Покеманов не будэт')
    }
  }

  static async fetchPokemonByUrl(url: string) {
    try {
      const response = await axios.get<PokemonType>(
       url,
        {
          method: "GET",
        }
      );
      if (response.status === 200) {
        return response.data;
      }
    }
    catch (error) {
      console.log(error);
    }
  }
}

export default MainPageService;