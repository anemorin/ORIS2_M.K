import styled from "styled-components"
import { Title } from "../MainStyledComponents"
import { Container } from "./PokemonStatistic"
import { useMemo } from "react"
import { PokemonType } from "../../types/MainPageTypes"

const AbilitiesContainer = styled.div`
  display: grid;
  flex-wrap: wrap;
  grid-template-columns: 1fr 1fr;
  gap: 12px;
  margin-top: 36px;
`

const AbilityContainer = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  border: 1px solid blue;
  background-color: blue;
  padding: 36px 12px;
  border-radius: 12px;
  color: white;
`

type Props = {
  pokemon: PokemonType;
};


const Abilities : React.FC<Props> = ({ pokemon }) => {
  const abilitiesList = useMemo(() => {
    return pokemon.abilities.slice(0, 6).map((ability) => {
      return (
        <AbilityContainer key={ability.name}>
          {ability.name}
        </AbilityContainer>
      );
    });
  }, [pokemon]);
  return (
    <Container>
      <Title>
        Abilities
      </Title>
      <AbilitiesContainer>
        {abilitiesList}
      </AbilitiesContainer>
    </Container>
  )
}

export default Abilities