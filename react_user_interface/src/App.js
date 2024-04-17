import React from 'react';
import ImageUpload from './Components/ImageUpload'

import './App.css';

function App() {
  return (
    <div>
      <h1>Modèle de reconnaissance d'espèces animales</h1>
      <h3>Veuillez télécharger une image d'animal</h3>
      <ImageUpload />
    </div>
  );
}

export default App;