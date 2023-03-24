import styled from "styled-components";
import { ContainerHeader } from "../../Components/Header/styles";

export const LoginBoxContainer = styled.div`
  display: flex;
  width: 40rem;
  height: 42.4rem;
  background: #f6f7f7;
  box-shadow: 0px 10px 19px rgba(178, 179, 181, 0.7);
  border-radius: 6px;
  margin-top: 8.25rem;
  flex-direction: column;
  align-items: center;
`;
export const WelcomeText = styled.h1`
  margin-top: 4.5rem;
  width: 100%;
  height: 7.9rem;
  font-family: "Inter";
  font-weight: 700px;
  font-size: 3.2rem;
  color: #7ac143;
  text-align: center;
`;
export const DivLogin = styled.div`
  display: flex;
  width: 32rem;
  height: 3.571rem;
  align-items: center;
  img {
    margin-left: -4rem;
    margin-top: 0.5rem;
  }
`;

export const LoginText = styled.h1`
  font-family: "Inter";
  font-style: normal;
  font-weight: 600;
  font-size: 16px;
  line-height: 19px;
  color: #000000;
  padding-top: 2rem;
`;
export const LoginForgotText = styled.h1`
  font-family: "Inter";
  font-style: normal;
  font-weight: 600;
  font-size: 14px;
  line-height: 19px;
  color: #000000;
  padding-top: 0.9rem;
  cursor: pointer;
`;
export const AsteriscText = styled.text`
  font-family: "Inter";
  font-style: normal;
  font-weight: 600;
  font-size: 16px;
  color: #e71c35;
`;

export const InputLogin = styled.input`
  width: 32rem;
  height: 3.571rem;
  background: #e5e6e6;
  box-shadow: inset 0px 3px 8px -1px rgba(0, 0, 0, 0.15);
  border-radius: 6px;
  font-family: "Inter";
  font-style: normal;
  font-weight: 400;
  font-size: 14px;
  line-height: 17px;
  color: #858585;
  padding-left: 1.5rem;
  margin-top: 0.5rem;
`;
export const ButtonLogin = styled.button`
  width: 32rem;
  height: 4rem;
  background: #da0812;
  border-radius: 2px;
  font-family: "Roboto";
  font-style: normal;
  font-weight: 500;
  font-size: 2rem;
  line-height: 23px;
  text-align: center;
  color: #ffffff;
  margin-top: 2.9rem;
  cursor: pointer;
`;

export const ContainerLogin = styled.div`
  display: flex;

  flex-direction: column;
  .GoLeft {
    align-self: flex-end;
  }
`;

export const Logo = styled.div`
  padding: 107px 64px;
`;
export const LoginMobile = styled.div`
  display: none;
  width: 100%;
  padding: 0px 20px;
`;

export const TextMobile = styled.div`
  margin-bottom: 20px;
  h1 {
    color: #53565a;
    font-size: 3.2rem;
  }
`;

export const InputSection = styled.div`
  & > div {
    margin-bottom: 28px;
  }
  & > div > input {
    display: flex;
    align-items: center;
    height: 5.5rem;
    width: 100%;
    background-color: #e5e6e6;
    padding: 8px 48px;
    border-radius: 4px 4px 0px 0px;
    margin-bottom: 8px;
    font-size: 2rem;
    color: #1c1b1fb2;
    font-weight: 400;
  }
`;
export const PasswordMobile = styled.input``;

export const EmailMobile = styled.input``;
export const EmailInput = styled.div`

`;

export const LeftImg = styled.img`
  position: absolute;
  margin-top: -5.5rem;
  margin-left: 0.5rem;
`;

export const RightImg = styled.img`
  position: absolute;
  margin-top: -5.5rem;
  margin-left: 32.5rem;
`;
export const PasswordInput = styled.div`
  & > div {
    width: 100%;
    display: flex;
    flex-direction: column;
  }
  & > input {
    display: flex;
    align-items: center;
    padding-right: 4px;
    height: 5.5rem;
    width: 100%;
    background-color: #e5e6e6;
    padding: 8px 4px;
    border-radius: 4px 4px 0px 0px;
    margin-bottom: 8px;
    font-size: 2rem;
    color: #1c1b1fb2;
    font-weight: 400;
  }

  span {
    text-align: end;
    color: #5a8f19;
    font-size: 14px;
    font-weight: 500;
  }
`;

export const ButtonSection = styled.div`
  display: flex;
  flex-direction: column;
  margin-top: 40px;
  gap: 12px;

  span,
  p {
    font-weight: 500;
    text-align: center;
  }
  span {
    font-size: 14px;
  }
  p {
    font-size: 16px;
    color: #131312;
  }

  p > span {
    color: #2b6c01;
    font-size: 16px;
  }
`;

export const LogIn = styled.button`
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 100px;
  height: 40px;
  width: 100%;
  gap: 8px;
  background: #e71c35;
  color: #fff;
  &:active {
    background: #f03c4c;
  }
`;
export const ScreenContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100vw;
  height: 100vh;

  @media (max-width: 450px) {
    ${LoginMobile} {
      display: block;
    }
    background-color: #ffffff;
    ${ContainerHeader} {
      display: none;
    }
    ${LoginBoxContainer} {
      display: none;
    }
  }
`;
