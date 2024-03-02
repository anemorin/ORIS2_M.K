import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import PokemonPage from './views/PokemonPage.tsx'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <React.StrictMode>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<App />}/>
          <Route path='/pokemon/:id' element={<PokemonPage />} />
        </Routes>
      </BrowserRouter>
    </React.StrictMode>,
  </React.StrictMode>,
)
