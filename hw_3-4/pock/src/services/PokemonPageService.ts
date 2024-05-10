import { PokemonType } from "../types/MainPageTypes";
import { ApiConnection } from "./ApiConnections";

class PokemonPageServices {
  static async fetchPokemonById(id: string) {
    try {
      const response = await ApiConnection.get<PokemonType>(
        `Pokemon/ByName/${id}`,
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