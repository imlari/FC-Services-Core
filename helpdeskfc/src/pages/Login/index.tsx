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
  InputMobile,
  TextMobile,
  ButtonLogin,
  InputSection,
  EmailInput,
  PasswordInput,
  ButtonSection,
  LogIn,
} from "./styles";
import HiddenIcon from './svg/hidden.svg'
import { Fclogomobile } from '../../Assets/fclogomobile';
import LoginIcon from './svg/login.svg'

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
            <InputMobile type="text" placeholder="Digite o seu email"></InputMobile>
          </EmailInput>
          <PasswordInput>
            <InputMobile type="password" placeholder="Digite a sua senha"></InputMobile>
            <span>Esqueci a senha</span>
          </PasswordInput>
        </InputSection>
        <ButtonSection>
          <LogIn>
            <img src={LoginIcon} />
            Entrar
            </LogIn>
           <span>OU</span>
           <p>Não possui uma conta? <span>Cadastre-se</span></p>
        </ButtonSection>
      </LoginMobile>
    </ScreenContainer>
  );
}


