import styled from "styled-components";

export const ScreenContainer = styled.div`
display:flex;
flex-direction: column;
align-items:center;
width:100vw;
height:100vh;
`

export const LoginBoxContainer = styled.div`
display: flex;

width: 40rem;
height: 42.4rem;
background: #F6F7F7;
box-shadow: 0px 10px 19px rgba(178, 179, 181, 0.7);
border-radius: 6px;
margin-top: 13.6rem;
flex-direction:column;
align-items:center
`
export const WelcomeText = styled.h1`
margin-top:4.5rem;
width:100%;
height:7.9rem;
font-family: 'Inter';
font-weight:700px;
font-size: 3.2rem;
color: #7AC143;
text-align:center;


`
export const DivLogin = styled.div`
display: flex;
width:32rem;
height:3.571rem;
align-items:center;
img{
margin-left:-4rem;
margin-top:0.5rem;
}
`

export const LoginText = styled.h1`
font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 16px;
line-height: 19px;
color: #000000;
padding-top: 2rem;

`
export const LoginForgotText = styled.h1`

font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 14px;
line-height: 19px;
color: #000000;
padding-top:0.9rem;
cursor: pointer;
`
export const AsteriscText = styled.text`

font-family: 'Inter';
font-style: normal;
font-weight: 600;
font-size: 16px;
color:#E71C35
`

export const InputLogin = styled.input`
width: 32rem;
height:3.571rem;
background: #E5E6E6;
box-shadow: inset 0px 3px 8px -1px rgba(0, 0, 0, 0.15);
border-radius: 6px;
font-family: 'Inter';
font-style: normal;
font-weight: 400;
font-size: 14px;
line-height: 17px;
color: #858585;
padding-left:1.5rem;
margin-top:.5rem;
`
export const ButtoLogin = styled.button`
width:32rem;
height:4rem;
background: #DA0812;
border-radius: 2px;
font-family: 'Roboto';
font-style: normal;
font-weight: 500;
font-size: 2rem;
line-height: 23px;
text-align: center;
color: #FFFFFF;
margin-top:2.9rem;
cursor: pointer;
`

export const ContainerLogin = styled.div`
display: flex;

flex-direction:column;
.GoLeft{
align-self:flex-end

}
`