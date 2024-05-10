import { PokemonResponseType } from "../types/MainPageTypes";
import { ApiConnection } from "./ApiConnections";

class MainPageService {
  static async fetchPokemons(page: number) {
    try {
      const response = await ApiConnection.get<PokemonResponseType[]>(`Pokemon/Pagination?offset=${page * 50}&limit=50`);

      if (response.status === 200) {
        return response.data;
      }
    }
    catch (error) {
      console.warn(error)
      alert('Покеманов не будэт')
    }
  }

  static async fetchPokemonsBySearch(search: string) {
    try {
      const response = await ApiConnection.get<PokemonResponseType[]>(`Pokemon/Filter/${search.toLocaleLowerCase()}`);
      if (response.status === 200) {
        return response.data;
      }
    }
    catch (error) {
      console.warn(error)
      alert('Покеманов не будэт')
    }
  }
}

export default MainPageService;