import styled from "styled-components";

export const Title = styled.div<{color?: string, size?: string}>`
  color: ${(props) => props.color ?? "black"};
  font-size: ${(props) => props.size ?? '24px'};
  font-weight: 400;
  @media (max-width: 560px) {
    font-size: 20px;
    font-weight: 400;
  }
`