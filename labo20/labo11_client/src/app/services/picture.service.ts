import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';

const domain = "https://localhost:7180/";

@Injectable({
  providedIn: 'root'
})
export class PictureService {

  constructor(public http : HttpClient) { }

  async postPicture(formData : any){
    
    let x = await lastValueFrom(this.http.post<any>(domain + "api/Pictures/PostPicture", formData));
    console.log(x);


  }

  async getPictureIds() : Promise<number[]>{
    let x = await lastValueFrom(this.http.get<any>(domain + "api/Pictures/GetPictureIds"));
    console.log(x);
    return x;

  }

  async deletePicture(id : number){
    let x = await lastValueFrom(this.http.delete<any>(domain + "api/Pictures/DeletePicture/"+id));
    console.log(x);


  }

}
