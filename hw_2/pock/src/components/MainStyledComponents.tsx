import styled from "styled-components";

export const Title = styled.div<{color?: string, size?: string}>`
  color: ${(props) => props.color ?? "black"};
  font-size: ${(props) => props.size ?? '24px'};
  font-weight: 400;
`