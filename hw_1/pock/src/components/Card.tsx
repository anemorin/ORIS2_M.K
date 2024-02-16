import styled from "styled-components";
import { PokemonResponseType, PokemonType } from "../types/MainPageTypes";
import { useState, useEffect } from "react";
import { toUpperCase } from "../utils";
import axios from "axios";

const PokemonContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  padding: 16px;
  /* gap: 12px; */
  border-radius: 12px;
  /* border: 1px solid black; */
  box-shadow: 0px 0px 6px 2px gray;
  background-color: white;
  width: 250px;
  height: 300px;
`;

const PokemonImage = styled.img`
  width: 150px;
  height: 150px;
`;

const CardTitleContainer = styled.div`
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: space-between;
`

const CardTitle = styled.p`
  color: blue;
  font-size: 20px;
`


const TypesContainer = styled.div`
  display: flex;
  margin-top: 12px;
  align-items: center;
  gap: 12px;
  flex-wrap: wrap;
`

const Type = styled.p`
  padding: 4px 24px;
  background-color: blue;
  color: white;
  border-radius: 6px;
  display: flex;
  align-items: center;
`

type Props = {
  pokemon: PokemonResponseType;
}

const Card: React.FC<Props> = ({ pokemon }) => {
  console.warn(pokemon);
  const [pokemonData, setPokemonData] = useState<PokemonType>();

  useEffect(() => {
    const fetchPokemon = async () => {
      try {
        const response = await axios.get<PokemonType>(
         pokemon.url,
          {
            method: "GET",
          }
        );
        setPokemonData(response.data);
      }
      catch (error) {
        console.log(error);
      }
    }

    fetchPokemon();
  }, [pokemon]);

  return (
    <PokemonContainer key={pokemonData?.id}>
      {
        pokemonData ? (
          <>
            <CardTitleContainer>
              <CardTitle>{toUpperCase(pokemon.name)}</CardTitle>
              <p>{`#${pokemonData?.id}`}</p>
            </CardTitleContainer>

            <PokemonImage src={
              pokemonData.sprites.other.home.front_default ??
              pokemonData.sprites.front_default
              }
            />
            <TypesContainer>
              {
                pokemonData.types.map((type, index) => (
                  <Type key={index}>
                    {toUpperCase(type.type.name)}
                  </Type>
                ))
              }
            </TypesContainer>


          </>
        ) : (
          <p>Покеман потерялся</p>
        )
      }

    </PokemonContainer>
  )
}

export default Card;
