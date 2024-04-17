import React from "react";
import { useState } from "react";
import axios from "axios";

function ImageUpload(){
    const [image, setImage] = useState('')
    function handleImage(e){
        console.log(e.target.files)
        setImage(e.target.files[0])
    }
    function handleApi(){
        var formData = new FormData()
        formData.append('fileContent', image)
        checkForm(formData, image)
        axios.post('https://localhost:7018/api/Prediction',formData, { headers: 
        {'Content-Type': 'multipart/form-data'},
        }).then((res)=>{
            console.log(res)
        })
    }
    function checkForm(f,i){
        console.log(f)
        console.log(i)
    }
    return(
        <div>
            <input type="file" name="file" accept="image/*" onChange={(handleImage)}/>
            <button onClick={handleApi}>submit</button>
        </div>
    )
}
export default ImageUpload;
