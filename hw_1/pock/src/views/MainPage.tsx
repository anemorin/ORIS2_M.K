import React, { useCallback, useEffect, useState } from "react";
import PageHeader from "../components/PageHeader";
import PageLayout from "../components/PageLayout";
import { PokemonResponseType, PokemonsResponseType } from "../types/MainPageTypes";
import axios from "axios";

const MainPage: React.FC = () => {
  const [searchValue, setSearchValue] = useState<string>("");
  const [pokemonData, setPokemonData] = useState<PokemonResponseType[]>([]);

  const fetchData = async () => {
    try {
      const response = await axios.get<PokemonsResponseType>("https://pokeapi.co/api/v2/pokemon/?limit=1300", {
        method: "GET",
      });

      if (response.status === 200) {
        setPokemonData(response.data.results);
      } else {
        alert('Покеманов не будэт')
      }
    }
    catch (error) {
      console.warn(error)
      alert('Покеманов не будэт')
    }

  };

  useEffect(() => {
    fetchData();
  }, []);

  const filterData = useCallback(() => {
    if (searchValue.length > 0) {
      const filteredData = pokemonData.filter(pokemon => {
        return pokemon.name.includes(searchValue);
      });
      return filteredData;
    }
    else {
      return pokemonData;
    }
  }, [searchValue, pokemonData])

  return (
    <>
      <PageHeader
        title="Who you are looking for?"
        searchValue={searchValue}
        onChangeSearch={setSearchValue}
      />
      <PageLayout
        data={filterData()}
      />
    </>
  )
}



export default MainPage;