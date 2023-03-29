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
  ContainerLogin,
  DivLogin,
  Logo,
  LoginMobile,
  TextMobile,
  ButtonLogin,
  InputSection,
  EmailInput,
  PasswordInput,
  ButtonSection,
  LogIn,
  EmailMobile,
  PasswordMobile,
  LeftImg,
  RightImg,
} from "./styles";
import HiddenIcon from './svg/hidden.svg'
import { Fclogomobile } from '../../Assets/fclogomobile';
import LoginIcon from './svg/login.svg';
import LockIcon from './svg/lock.svg';
import EmailIcon from './svg/email.svg';
import CancelIcon from './svg/cancel.svg';
import EyeIcon from './svg/eye.svg';
import EyeClosedIcon from './svg/eyeClosed.svg'
import { useState } from 'react';

export const Login = () => {
  const navigate = useNavigate();

  const [passwordVisible, setPasswordVisible] = useState(false);


  return (
    <ScreenContainer>
      <Header />
      <LoginBoxContainer>
        <ContainerLogin>
          <WelcomeText>Seja bem vindo(a)!</WelcomeText>
          <LoginText>Email <AsteriscText>*</AsteriscText></LoginText>
          <InputLogin type={'text'} placeholder="Digite seu email" required></InputLogin>
          <LoginText>Senha <AsteriscText>*</AsteriscText></LoginText>
          <DivLogin>
            <InputLogin type={'password'} placeholder="Digite sua senha" required></InputLogin>
            <img src={HiddenIcon}></img>
          </DivLogin>
          <LoginForgotText className="GoLeft">Esqueci a senha</LoginForgotText>
          <ButtonLogin onClick={() => navigate("/mainpage")}>Entrar</ButtonLogin>
        </ContainerLogin>
      </LoginBoxContainer>

      <LoginMobile>
        <Logo>
          <Fclogomobile />
        </Logo>
        <TextMobile>
          <h1>Entrar</h1>
        </TextMobile>
        <InputSection>
          <EmailInput>
            <EmailMobile type="text" placeholder="Digite o seu email" required></EmailMobile>
            <LeftImg src={EmailIcon} alt="Email Icon" />
            <RightImg src={CancelIcon} alt="Delete email" />
          </EmailInput>
          <PasswordInput>
            <PasswordMobile type={passwordVisible ? "text" : "password"} placeholder="Digite a sua senha" required></PasswordMobile>
            <LeftImg src={LockIcon} alt="Lock Icon" />
            <RightImg src={passwordVisible ? EyeClosedIcon : EyeIcon} alt="Hide password" onClick={() => setPasswordVisible(!passwordVisible)} />
            <div>
              <span>Esqueci a senha</span>
            </div>
          </PasswordInput>
        </InputSection>
        <ButtonSection>
          <LogIn type="submit">
            <img src={LoginIcon} alt="Login Icon"></img>
            Entrar
          </LogIn>
          <span>OU</span>
          <p>Não possui uma conta? <span>Cadastre-se</span></p>
        </ButtonSection>
      </LoginMobile>
    </ScreenContainer>
  );
}


