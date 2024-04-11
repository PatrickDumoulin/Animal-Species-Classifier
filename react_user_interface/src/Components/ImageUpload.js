import React from "react";
import { useState } from "react";
import axios from "axios";

function ImageUpload(){
    const [image, setImage] = useState('')
    function handleImage(e){
        console.log(e.target.files)
        setImage(e.target.files[0])
        console.log(image)
    }
    function handleApi(){
        const formData = new FormData()
        formData.append('image', image)
        axios.post('https://localhost:53770/predictImageSource',formData).then((res)=>{
            console.log(res)
        })
    }
    return(
        <div>
            <input type="file" name="file" onChange={(handleImage)}/>
            <button onClick={handleApi}>submit</button>
        </div>
    )
}
export default ImageUpload;
