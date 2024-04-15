import React from 'react';
import ImageUploadForm from './Components/ImageUploadForm'
import ImageUpload from './Components/ImageUpload'

import './App.css';

function App() {
  return (
    <div>
      <h1>Upload d'image 1</h1>
      <ImageUploadForm />
      <h1>Upload d'image 2</h1>
      <ImageUpload />
    </div>
  );
}

export default App;