import styled from "styled-components";
import { PokemonResponseType } from "../types/MainPageTypes";
import { toId, toUpperCase } from "../utils";
import { useNavigate } from "react-router-dom";
import { abilityColors } from "../enums";

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
      {pokemon ? (
        <CardContainer
          key={pokemon.id}
          onClick={() => navigate(`/pokemon/${pokemon.id}`)}
        >
          <CardTitleContainer>
            <CardTitle>{toUpperCase(pokemon.name)}</CardTitle>
            <p>{toId(pokemon.id)}</p>
          </CardTitleContainer>

          <PokemonImage
            src={pokemon?.imageUrl}
          />
          <TypesContainer>
            {pokemon?.types.map((type, index) => (
              <Type
                key={index}
                type={type.type.name}
              >
                {toUpperCase(type.type.name)}
              </Type>
            ))}
          </TypesContainer>
        </CardContainer>
      ) : null}
    </>
  );
}

export default Card;