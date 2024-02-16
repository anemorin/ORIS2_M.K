import React, { useCallback, useEffect, useState } from "react";
import PageHeader from "../components/PageHeader";
import PageLayout from "../components/PageLayout";
import { PokemonResponseType, PokemonsResponseType } from "../types/MainPageTypes";

const MainPage: React.FC = () => {
  const [searchValue, setSearchValue] = useState<string>("");
  const [pokemonData, setPokemonData] = useState<PokemonResponseType[]>([]);

  const fetchData = async () => {
    const response = await fetch("https://pokeapi.co/api/v2/pokemon/?limit=1300", {
      method: "GET",
    });

    if (response.ok) {
      const data: PokemonsResponseType = await response.json();
      setPokemonData(data.results);
    } else {
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