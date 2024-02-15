import React, { useEffect, useState } from "react";
import PageHeader from "../components/PageHeader";
import { PokemonDataResponseType, PokemonResponseType, PokemonType } from "../types/MainPageTypes";
import PageLayout from "../components/PageLayout";

const MainPage: React.FC = () => {
  const [searchValue, setSearchValue] = useState<string>("");
  const [pokemonData, setPokemonData] = useState<PokemonType[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetch("https://pokeapi.co/api/v2/pokemon/?limit=1300", {
        method: "GET",
      });

      if (response.ok) {
        const data: PokemonResponseType = await response.json();
        const preparedData = await Promise.all(data.results.map(async (i) => {
          const imgResponse = await fetch(i.url);
          const imgData: PokemonDataResponseType = await imgResponse.json();
          return {
            ...i,
            id: imgData.id,
            img: imgData.sprites.front_default,
          } as PokemonType;
        }));
        setPokemonData(preparedData);
      } else {
        alert('Покеманов не будэт')
      }
    };

    fetchData();
  }, []);

  // const onSearch = useCallback(async () => {
  //   const response = await fetch(`https://pokeapi.co/api/v2/pokemon/${searchValue}`)

  //   if (response.ok) {
  //     const data: PokemonResponseType = await response.json();
  //     setPokemonData(data.results);
  //   } else {
  //     alert('Покеманов не будэт')
  //   }
  // }, [searchValue])

  return (
    <>
      <PageHeader
        title="Who you are looking for?"
        searchValue={searchValue}
        onChangeSearch={setSearchValue}
      // onSearch={onSearch}
      />
      <PageLayout
        data={pokemonData}
      />
    </>
  )
}



export default MainPage;