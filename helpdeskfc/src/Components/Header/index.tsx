import { ContainerHeader} from "./styles";

import SecurePage from './svg/SecurePage.svg'
import { FCLogo } from "./svg/fclogo";




export const Header = () => {
    return(
        <>
        
       <ContainerHeader>
          <FCLogo/>
          <img src={SecurePage}></img>
        </ContainerHeader>

        
       
        
        
        </>
    );
}