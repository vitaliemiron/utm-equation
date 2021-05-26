import styled from 'styled-components';

export const Ff = styled.div`
  display: grid;
  width: 100%;
  justify-content: center;

  label {
    display: grid;
    gap: 20px;
    grid-template-columns: 20px 300px;
    align-items: center;
  }

  .submit {
    margin-top: 50px;
    width: 300px;
    justify-self: end;
  }
`;
