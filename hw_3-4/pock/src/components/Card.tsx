import styled from "styled-components";
import { PokemonResponseType } from "../types/MainPageTypes";
import { useNavigate } from "react-router-dom";
import { abilityColors } from "../enums";
import { toId, toUpperCase } from "../utils";

export const CardContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  padding: 16px;
  border-radius: 12px;
  box-shadow: 0px 0px 6px 2px gray;
  background-color: white;
  width: 250px;
  height: 300px;
`;

const PokemonImage = styled.img`
  width: 150px;
  height: 150px;
`;

export const CardTitleContainer = styled.div`
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: space-between;
  flex-wrap: wrap;
`

export const CardTitle = styled.p`
  color: blue;
  font-size: 20px;
`


export const TypesContainer = styled.div`
  display: flex;
  margin-top: 12px;
  align-items: center;
  gap: 12px;
  flex-wrap: wrap;
  justify-content: flex-end;
`

export const Type = styled.p<{ type: string }>`
  padding: 4px 24px;
  background-color: ${(props) => abilityColors[props.type as keyof typeof abilityColors] ?? 'blue'};
  color: white;
  border-radius: 6px;
  display: flex;
  align-items: center;
`

type Props = {
  pokemon: PokemonResponseType;
}

const Card: React.FC<Props> = ({ pokemon }) => {
  const navigate = useNavigate();

  return (
    <>
      {pokemon && (
        <CardContainer
          key={pokemon.pokemon.name}
          onClick={() => navigate(`/pokemon/${pokemon.pokemon.name}`)}
        >
          <CardTitleContainer>
            <CardTitle>{toUpperCase(pokemon.pokemon.name)}</CardTitle>
            <p>{toId(pokemon.pokemon.order)}</p>
          </CardTitleContainer>

          <PokemonImage
            src={pokemon.pokemon.imgUrl}
          />
          <TypesContainer>
            {pokemon?.types.map((type, index) => (
              <Type
                key={index}
                type={type}
              >
                {toUpperCase(type)}
              </Type>
            ))}
          </TypesContainer>
        </CardContainer>
      )}
    </>
  );
}

export default Card;
