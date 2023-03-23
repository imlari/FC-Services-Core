import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Header } from "../../Components/Header";
import {
  LoginBoxContainer,
  ScreenContainer,
  WelcomeText,
  LoginText,
  AsteriscText,
  InputLogin,
  LoginForgotText,
  ButtoLogin,
  ContainerLogin,
  DivLogin,
} from "./styles";
import HiddenIcon from './svg/hidden.svg'

export const Login = () => {
  const navigate = useNavigate();
  return (
    <ScreenContainer>
      <Header />
      <LoginBoxContainer>

        <ContainerLogin>

          <WelcomeText>Seja bem vindo(a)!</WelcomeText>
          <LoginText>Email <AsteriscText>*</AsteriscText></LoginText>
          <InputLogin type={'text'} placeholder="Digite seu email"></InputLogin>
          <LoginText>Senha <AsteriscText>*</AsteriscText></LoginText>
          <DivLogin>
            <InputLogin type={'password'} placeholder="Digite sua senha"></InputLogin>
            <img src={HiddenIcon}></img>
          </DivLogin>
          <LoginForgotText className="GoLeft">Esqueci a senha</LoginForgotText>

          <ButtoLogin onClick={() => navigate("/mainpage")}>Entrar</ButtoLogin>

        </ContainerLogin>


      </LoginBoxContainer>
    </ScreenContainer>


  );
}


