import styled from "styled-components"
import { PokemonResponseType } from "../types/MainPageTypes"
import React from "react";
import Card from "./Card";

const LayoutContainer = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: row;
  flex-wrap: wrap;
  padding: 36px 0;
  gap: 24px;
`

type Props = {
  data: PokemonResponseType[];
}

const PageLayout : React.FC<Props> = ({data}) => {
  return (
    <LayoutContainer>
      {data.length
      ? (data.map((pokemon) => (
        <Card
          key={pokemon.name}
          pokemon={pokemon}
        />
      )))
      : 'Покеманов не будэт'}
    </LayoutContainer>
  )
}

export default PageLayout;