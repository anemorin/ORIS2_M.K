import styled from "styled-components";
import { PokemonType } from "../../types/MainPageTypes";
import { Title } from "../MainStyledComponents";
import { Container } from "./PokemonStatistic";
import { useMemo } from "react";

const Header = styled.div`
  display: flex;
  width: 100%;
  justify-content: space-between;
  align-items: center;
`

const Button = styled.button`
  padding: 12px 24px;
  background-color: black;
  color: white;
  border: none;
  border-radius: 24px;
`

const MovesContainer = styled.div`
  display: grid;
  flex-wrap: wrap;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 12px;
  margin-top: 36px;
`

const MoveContainer = styled.div`
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


const Moves: React.FC<Props> = ({ pokemon }) => {
  const movesList = useMemo(() => {
    return pokemon.moves.slice(0, 6).map((move) => {
      return (
        <MoveContainer key={move.move.name}>
          {move.move.name}
        </MoveContainer>
      );
    });
  }, [pokemon]);

  return (
    <Container>
      <Header>
        <Title>Moves</Title>
        <Button>See all</Button>
      </Header>
      <MovesContainer>
        {movesList}
      </MovesContainer>
    </Container>
  );
};


export default Moves