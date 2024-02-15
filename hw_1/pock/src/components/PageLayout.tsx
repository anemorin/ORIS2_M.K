import styled from "styled-components"
import { PokemonType } from "../types/MainPageTypes"
import React from "react";

const LayoutContainer = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
  flex-wrap: wrap;
  padding: 36px 0;
  gap: 12px;
`

const PokemonContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding: 12px;
  gap: 12px;
  border-radius: 12px;
  border: 1px solid black;
  background-color: white;
  width: 200px;
  height: 200px;
`;

const PokemonImage = styled.img`
  width: 50%;
  height: 50%;
`;

type Props = {
  data: PokemonType[];
}

const PageLayout : React.FC<Props> = ({data}) => {
  return (
    <LayoutContainer>
      {data.length
      ? (data.map((pokemon, index) => (
        <PokemonContainer key={index}>
          <PokemonImage src={pokemon.img} />
          <p>{pokemon.name.toUpperCase()}</p>
        </PokemonContainer>
      )))
      : 'Покеманов не будэт'}
    </LayoutContainer>
  )
}

export default PageLayout;