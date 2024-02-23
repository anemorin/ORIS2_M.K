import React, { useCallback, useEffect, useState } from "react";
import PageHeader from "../components/PageHeader";
import PageLayout from "../components/PageLayout";
import { PokemonResponseType } from "../types/MainPageTypes";
import MainPageService from "../services/MainPageService";

const MainPage: React.FC = () => {
  const [searchValue, setSearchValue] = useState<string>("");
  const [pokemonData, setPokemonData] = useState<PokemonResponseType[]>([]);
  const [page, setPage] = useState<number>(1);
  const [totalCount, setTotalCount] = useState<number>();
  const [fetchState, setFetchState] = useState<boolean>(false);

  const initialFetch = async () => {
    setFetchState(true);
    const response = await MainPageService.fetchPokemons(page * 40);
    setPokemonData(response?.results ?? []);
    setTotalCount(response?.count);
    setFetchState(false);
  }

  useEffect(() => {
    initialFetch();
  }, [page]);

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

  const handleScroll = () => {
    if ((window.innerHeight + document.documentElement.scrollTop + 1 >= document.documentElement.scrollHeight)
      && totalCount !== pokemonData.length
      && !fetchState
      )
    {
      setPage(prev => prev + 1);
    }
  }

  useEffect(() => {
    window.addEventListener("scroll", handleScroll)

    return () => {
      window.removeEventListener("scroll", handleScroll);
    }
  }, [])

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