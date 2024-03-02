import styled from "styled-components";
import { PokemonType } from "../../types/MainPageTypes";
import { Title } from "../MainStyledComponents";
import { Container } from "./PokemonStatistic";
import { getFoots, getIbs } from "../../utils";

type Props = {
  pokemon: PokemonType;
};

const PokemonBreeding = styled.div`
  display: flex;
  width: 100%;
  justify-content: center;
  gap: 24px;
`

const BreedingContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
  gap: 4px;
  @media (max-width: 560px) {
    font-size: 12px;
  }
`

const BreedingItem = styled.div`
  background-color: #f8f9fb;
  border-radius: 12px;
  border: 1px solid #d8d8d8;
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 24px;
  padding: 12px;
`

const Breeding : React.FC<Props> = ({ pokemon }) => {
  return (
    <Container>
      <Title>
        Breeding
      </Title>
      <PokemonBreeding>
        <BreedingContainer>
          <p>Height</p>
          <BreedingItem>
            <p>{getFoots(pokemon.height)}</p>
            <p>{pokemon.height / 10} m</p>
          </BreedingItem>
        </BreedingContainer>
        <BreedingContainer>
          <p>Weight</p>
          <BreedingItem>
            <p>{getIbs(pokemon.weight / 10)}</p>
            <p>{pokemon.weight / 10} kg</p>
          </BreedingItem>
        </BreedingContainer>
      </PokemonBreeding>
    </Container>
  )
}

export default Breeding;