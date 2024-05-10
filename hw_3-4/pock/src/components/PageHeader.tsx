import styled from "styled-components";
import InputComponent from "./Input";
import { icons } from "../enums";
import { useNavigate } from "react-router-dom";

const HeaderContainer = styled.div<{align?: string}>`
  background-color: blue;
  width: 100%;
  display: flex;
  align-items: ${(props) => props.align ?? "center"};
  flex-direction: column;
  padding: 36px 24px;
`;

const Title = styled.p`
  padding: 24px 12px;
  color: white;
  font-size: 32px;
`;

// const PokeballContainer = styled.div`
//   /* position: absolute; */
//   z-index: 1000;
//   left: 80%;
//   top: -10%;
//   width: 30%;
//   height: 30%;
//   opacity: 50%;
//   overflow: hidden;
//   img {
//     width: 100%;
//     height: 100%;
//   }
// `
// const SmallPokeballContainer = styled.div`
//   /* position: absolute; */
//   left: 85%;
//   top: -2%;
//   width: 130px;
//   height: 130px;
//   opacity: 50%;
//   overflow: hidden;
//   img {
//     width: 100%;
//     height: 100%;
//   }
// `

const SearchContainer = styled.div`
  width: 100%;
  max-width: 560px;
`

const BackButton = styled.button`
  background: none;
  border: none;
  display: flex;
  margin-left: 24px;
  img {
    width: 36px;
    height: 36px;
    filter: invert(100%) sepia(0%) saturate(0%) hue-rotate(261deg) brightness(104%) contrast(101%);
  }
`

interface Props {
  title?: string;
  searchValue?: string;
  onChangeSearch?: (s: string) => void;
  onSearch?: () => void;
}

const PageHeader: React.FC<Props> = ({
  title,
  searchValue,
  onChangeSearch,
  onSearch,
}) => {
  return (
    <HeaderContainer>
      {title && <Title>{title}</Title>}
      {/* <PokeballContainer>
        <img src={icons.pokeball} alt="pokeball" />
      </PokeballContainer> */}
      <SearchContainer>
        <InputComponent
          value={searchValue}
          onChangeValue={onChangeSearch!}
          onSubmit={onSearch}
        />
      </SearchContainer>
    </HeaderContainer>
  );
};

export const SmallHeader = () => {
  const navigate = useNavigate();
  return (
    <HeaderContainer
      align="flex-start"
    >
      <BackButton
        onClick={() => navigate(-1)}
      >
        <img src={icons.arroy} alt="back" />
      </BackButton>
      {/* <SmallPokeballContainer>
        <img src={icons.pokeball} alt="pokeball" />
      </SmallPokeballContainer> */}
    </HeaderContainer>
  )
}


export default PageHeader;