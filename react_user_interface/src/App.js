import React from 'react';
import ImageUploadForm from './Components/ImageUploadForm'
import ImageUpload from './Components/ImageUpload'

import './App.css';

function App() {
  return (
    <div>
      <h1>Upload d'image Form</h1>
      <ImageUploadForm />
      <h1>Upload d'image Axios Fonctionnel</h1>
      <ImageUpload />
    </div>
  );
}

export default App;