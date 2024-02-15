import styled from "styled-components";
import InputComponent from "./Input";

const HeaderContainer = styled.div`
  background-color: blue;
  width: 100%;
  display: flex;
  align-items: center;
  flex-direction: column;
  padding: 36px 0;
`;

const Title = styled.p`
  padding: 24px 12px;
  color: white;
  font-size: 32px;
`;

type Props = {
  title?: string;
  searchValue?: string;
  onChangeSearch: (s: string) => void;
  onSearch?: () => void;
}


const PageHeader : React.FC<Props> = ({title, searchValue, onChangeSearch, onSearch})  => {
  return (
    <HeaderContainer>
      {title && <Title>{title}</Title>}
      <InputComponent
        value={searchValue}
        onChangeValue={onChangeSearch}
        onSubmit={onSearch}
      />
    </HeaderContainer>
  )
}

export default PageHeader;