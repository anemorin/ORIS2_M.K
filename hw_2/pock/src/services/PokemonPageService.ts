import axios from "axios";
import { PokemonType } from "../types/MainPageTypes";

class PokemonPageServices {
  static async fetchPokemonById(id: string) {
    try {
      const response = await axios.get<PokemonType>(
        `https://pokeapi.co/api/v2/pokemon/${id}`,
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

export default PokemonPageServices;