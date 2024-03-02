import React, { useCallback, useEffect, useState } from "react";
import PageHeader from "../components/PageHeader";
import PageLayout from "../components/PageLayout";
import { PokemonResponseType } from "../types/MainPageTypes";
import MainPageService from "../services/MainPageService";
import { useEffectOnce } from "react-use";

const MainPage: React.FC = () => {
  const [searchValue, setSearchValue] = useState<string>("");
  const [pokemonData, setPokemonData] = useState<PokemonResponseType[]>([]);
  const [page, setPage] = useState<number>(1);
  const [totalCount, setTotalCount] = useState<number>();
  const [fetchState, setFetchState] = useState<boolean>(false);
  const [isMyFetching,setIsFetchingDown]=useState(false)

  const writePokemons = useCallback((pokemons: PokemonResponseType[]) => {
    const pokemonsSet = new Set([...pokemonData.map((pok) => pok.id)]);
    return [...pokemonData, ...(pokemons ?? []).filter((pok) => !pokemonsSet.has(pok.id))]
  }, [pokemonData])

  const initialFetch = useCallback(async () => {
    setFetchState(true);
    if (searchValue.length > 0) {
      const response = await MainPageService.fetchPokemonsBySearch(searchValue, page);
      const prepPokemonData = writePokemons(response?.pokemons ?? []);
      setPokemonData([...prepPokemonData]);
      setTotalCount(response?.totalCount);
    } else {
      const response = await MainPageService.fetchPokemons(page);
      const prepPokemonData = writePokemons(response?.pokemons ?? []);
      setPokemonData([...prepPokemonData]);
      setTotalCount(response?.totalCount);
    }
    setFetchState(false);
  }, [page, searchValue])

  const onSearchHandle = async () => {
    setPage(1);
    setPokemonData([]);
    if (searchValue.length > 0) {
      const response = await MainPageService.fetchPokemonsBySearch(searchValue, 1);
      setPokemonData([...(response?.pokemons ?? [])]);
    } else {
      initialFetch()
    }
  }

  useEffect(() => {
    initialFetch();
  }, [page]);



  useEffect(()=>{
    if(isMyFetching)
    {
      setPage(page+1)
      setIsFetchingDown(false)
    }
  },[isMyFetching])

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const scrollHandler=(e: any):void=>{
    if(e.target.documentElement.scrollHeight - e.target.documentElement.scrollTop-window.innerHeight < 50
      && totalCount !== pokemonData.length
      && !fetchState)
    {
        setIsFetchingDown(true)
        window.scrollTo(0,(e.target.documentElement.scrollHeight + e.target.documentElement.scrollTop));
    }
}

  useEffectOnce(() => {
    window.addEventListener("scroll", scrollHandler)

    return () => {
      window.removeEventListener("scroll", scrollHandler);
    }
  })

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
