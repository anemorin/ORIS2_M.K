import styled from "styled-components";
import { icons } from "../enums";

const InputContainer = styled.div`
  padding: 4px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: center;
  background-color: white;
  border-radius: 32px;
  gap: 8px;
  height: 30%;
`;

const Input = styled.input`
  padding: 8px;
  font-size: 24px;
  background: none;
  border: none;
  width: 70%;
`

const Button = styled.button`
  padding: 12px 24px;
  font-size: 24px;
  color: white;
  background-color: black;
  border-radius: 32px;
`

const Icon = styled.img`
  width: 48px;
  height: 48px;
  padding: 8px;
`

type Props = {
  value?: string;
  onChangeValue: (s: string) => void;
  onSubmit?: () => void;
}

const InputComponent : React.FC<Props> = ({value, onChangeValue, onSubmit})  => {
  return (
    <InputContainer>
        <Icon src={icons.search} alt="search" />
        <Input
          type="text"
          onChange={(s) => onChangeValue(s.target.value)}
          value={value}
          placeholder="e.g. Pikachu"
        />
        <Button onClick={onSubmit}>GO</Button>
      </InputContainer>
  )
}

export default InputComponent;