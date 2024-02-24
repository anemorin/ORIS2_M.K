import React, { useEffect, useState } from "react";
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
    if (searchValue.length === 0) {
      initialFetch();
    }
  }, [page, searchValue]);

  const onSearchHandle = async () => {
    if (searchValue.length > 0) {
      setPokemonData([]);
      const response = await MainPageService.fetchPokemons(1300);
      const filteredData = response?.results.filter(pokemon => {
        return pokemon.name.includes(searchValue.toLowerCase());
      });
      setPokemonData(filteredData ?? [])
    }
  }


  const handleScroll = () => {
    if (
      (
        (window.innerHeight + document.documentElement.scrollTop + 1 >= document.documentElement.scrollHeight)
        && totalCount !== pokemonData.length
      )
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
        onSearch={onSearchHandle}
      />
      <PageLayout
        data={pokemonData}
      />
    </>
  )
}



export default MainPage;