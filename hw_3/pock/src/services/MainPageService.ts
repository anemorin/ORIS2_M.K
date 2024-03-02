import axios from "axios";
import { PokemonsResponseType } from "../types/MainPageTypes";

class MainPageService {
  static async fetchPokemons(page: number) {
    try {
      const response = await axios.get<PokemonsResponseType>(`http://localhost:5000/api/Pokemon?page=${page}`, {
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

  static async fetchPokemonsBySearch(search: string, page: number) {
    try {
      const response = await axios.get<PokemonsResponseType>(
        `http://localhost:5000/api/Pokemon/GetByFilter?page=${page}&search=${search}`, {
          method: "GET"
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
}

export default MainPageService;