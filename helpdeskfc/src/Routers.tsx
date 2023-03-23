import { Route, Routes } from 'react-router-dom'
import { AttendancesPage } from './pages/AttendancesPage'
import { ConsultPage } from './pages/ConsultPage'
import { LoginPage } from './pages/LoginPage'
import { MainPage } from './pages/MainPage'
import { ResquestPage } from './pages/RequestPage'
import { SectoresPage } from './pages/SectoresPage'

export const Routers = () => {
  return (
        
    <Routes>
      <Route path='/' element={<LoginPage/>}/>
      <Route path='/mainpage' element = {<MainPage/>}/>
      <Route path='/attendancespage' element = {<AttendancesPage/>}/>
      <Route path='/requestspage' element = {<ResquestPage/>}/>
      <Route path='/consultspage' element = {<ConsultPage/>}/>
      <Route path='/sectorespage' element = {<SectoresPage/>}/>
    </Routes> 
    

  );
}

