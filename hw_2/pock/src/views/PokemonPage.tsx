import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { SmallHeader } from "../components/PageHeader";
import PokemonPageServices from "../services/PokemonPageService";
import { PokemonType } from "../types/MainPageTypes";
import PokemonStatistic from "../components/PokemonPage/PokemonStatistic";
import styled from "styled-components";
import Breeding from "../components/PokemonPage/Breeding";
import Moves from "../components/PokemonPage/Moves";

const PageContainer = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  margin-top: 36px;
  gap: 36px;
`

const PokemonPage : React.FC = () => {
  const { id } = useParams();
  const [pokemonData, setPokemonData] = React.useState<PokemonType>();

  const initialFetch = async () => {
    if (id) {
      const response = await PokemonPageServices.fetchPokemonById(id);
      setPokemonData(response);
    }
  }

  useEffect(() => {
    initialFetch();
  }, [id]);

  return (
    <>
      <SmallHeader />
      <PageContainer>
        {pokemonData && (
          <>
            <PokemonStatistic
              pokemon={pokemonData}
            />
            <Breeding
              pokemon={pokemonData}
            />
            <Moves
              pokemon={pokemonData}
            />
          </>
        )}

      </PageContainer>
    </>
  )
}

export default PokemonPage;