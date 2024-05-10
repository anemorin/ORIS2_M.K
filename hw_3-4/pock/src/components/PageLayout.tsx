import styled from "styled-components"
import { PokemonResponseType } from "../types/MainPageTypes"
import React, { useCallback, useMemo } from "react";
import Card from "./Card";

const LayoutContainer = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
  flex-wrap: wrap;
  padding: 36px 12px;
  gap: 24px;
`

type Props = {
  data: PokemonResponseType[];
}

const PageLayout : React.FC<Props> = ({data}) => {

  const pokemonCard = useCallback((pokemon : PokemonResponseType) => {
    return (
      <Card
          key={pokemon.pokemon.id}
          pokemon={pokemon}
        />
    )
  }, [])

  const pokemonsCard = useMemo(() => {
    return (
      data.length
      ? (data.map((pokemon) => (
        pokemonCard(pokemon)
      )))
      : (
        <p>Покеманов не будет</p>
      )
    )
  }, [data, pokemonCard])

  return (
    <LayoutContainer>
      {pokemonsCard}
    </LayoutContainer>
  )
}

export default PageLayout;