import styled from "styled-components";
import { PokemonType } from "../../types/MainPageTypes";
import { toId, toUpperCase } from "../../utils";
import { Type, TypesContainer } from "../Card";
import { backgroundStatsColors, statsColors } from "../../enums";
import { Title } from "../MainStyledComponents";

type Props = {
  pokemon: PokemonType;
};

const CardHeader = styled.div`
  display: flex;
  align-items: center;
  width: 100%;
  justify-content: space-between;
`;

export const Container = styled.div`
  display: flex;
  flex-direction: column;
  width: 90%;
  max-width: 560px;
  justify-content: space-between;
  padding: 28px;
  border-radius: 12px;
  box-shadow: 0px 0px 6px 2px gray;
  background-color: white;
`

const TitleContainer = styled.div`
  display: flex;
  flex-direction: column;
  width: 40%;
`

const PokemonData = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
`;

const PokemonDataItem = styled.div`
  display: flex;
  flex-direction: column;
  gap: 12px;
  width: 40%;
`

const PokemonDataItemBar = styled.div<{statName: string}>`
  margin-top: 4px;
  display: flex;
  width: 100%;
  background-color: ${
    (props) => backgroundStatsColors[props.statName as keyof typeof backgroundStatsColors]
  };
  height: 8px;
  border-radius: 8px;
`

const StatBar = styled.div<{stat: number, statName: string}>`
  width: ${(props) => props.stat}%;
  background-color: ${(props) => statsColors[props.statName as keyof typeof statsColors]};
  border-radius: 8px;
`

const PokemonImage = styled.img`
  width: 40%;
  height: 40%;
`

const PokemonStatistic : React.FC<Props> = ({ pokemon }) => {
  return (
    <Container>
      <CardHeader>
        <TitleContainer>
          <p>{toId(pokemon.order)}</p>
          <Title
            color='blue'
          >
            {toUpperCase(pokemon.name)}
          </Title>
        </TitleContainer>
        <TypesContainer>
          {pokemon?.typesList.map((type, index) => (
            <Type
              key={index}
              type={type}
            >
              {toUpperCase(type)}
            </Type>
          ))}
        </TypesContainer>
      </CardHeader>
      <PokemonData>
        <PokemonDataItem>
          {pokemon.stat
            .filter((pok) => !['special-attack', 'special-defense'].includes(pok.name))
            .map((stat, index) => (
            <div key={index}>
              <p>{toUpperCase(stat.name)}</p>
              <PokemonDataItemBar
                statName={stat.name}
              >
                <StatBar
                  stat={stat.value}
                  statName={stat.name}
                />
              </PokemonDataItemBar>
            </div>
          ))}
        </PokemonDataItem>
        <PokemonImage src={pokemon.imgUrl} />
      </PokemonData>
    </Container>
  )
}

export default PokemonStatistic;