import React, { useState } from "react";
import axios from "axios";

function ImageUpload() {
    const [image, setImage] = useState(''); // Etat de l'image
    const [prediction, setPrediction] = useState(''); // Ajouter cet état pour la prédiction

    function handleImage(e) {
        setImage(e.target.files[0]);
    }

    function handleApi() {
        var formData = new FormData();
        formData.append('fileContent', image);
        axios.post('https://localhost:7018/api/Prediction', formData, {
            headers: { 'Content-Type': 'multipart/form-data' },
        }).then((res) => {
            console.log(res);
            setPrediction(res.data);
        }).catch((error) => {
            console.error(error);
        });
    }

    return (
        <div class="Prediction">
            <input type="file" name="file" accept="image/*" onChange={handleImage} />
            <button onClick={handleApi}>Démarrer la prédiction</button>
            {prediction && <p> Résultat de l'analyse : {prediction}</p>} 
        </div>
    );
}

export default ImageUpload;
