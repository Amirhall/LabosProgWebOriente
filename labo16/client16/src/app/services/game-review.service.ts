import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Review } from '../models/review';

const domain = "https://localhost:7013/";

@Injectable({
  providedIn: 'root'
})
export class GameReviewService {

  constructor(public http : HttpClient) { }

  // Si une des fonctions ci-dessous n'a pas de RETURN actuellement, c'est que vous n'aurez pas à en mettre.

  async register(username : string, email : string, password : string, passwordConfirm : string){
    let registerDTO = {
      username : username, 
      email : email, 
      password : password, 
      passwordConfirm : passwordConfirm
  };

  let x = await lastValueFrom(this.http.post<any>(domain + "api/Users/Register", registerDTO));
  console.log(x);



  }

  async login(username : string, password : string){

    let loginDTO =  {
      username : username,
      password : password
  };

  let x = await lastValueFrom(this.http.post<any>(domain + "api/Users/Login", loginDTO));
  console.log(x);

  // 🔑 Très important de stocker le token quelque part pour pouvoir l'utiliser dans les futures requêtes !
  localStorage.setItem("token", x.token);

  }

  async getReviews(){

    // À remplacer
    let x = await lastValueFrom(this.http.get<any>(domain + "api/Reviews/GetReview"));
    console.log(x);
  
    return x;

  }

  async postReview(text : string, game : string){
    let token = localStorage.getItem("token");
    let httpOptions = {
        headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
        })
    };

    let reviewDTO = {
      Text : text,
      Game : game
    }

    let x = await lastValueFrom(this.http.post<any>(domain + "api/Reviews/PostReview", reviewDTO,httpOptions));
    console.log(x);
    return x;
  }

  async deleteReview(id : number){
    let token = localStorage.getItem("token");
    let httpOptions = {
        headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
        })
    };

    let x = await lastValueFrom(this.http.delete<any>(domain + "api/Reviews/DeleteReview/" + id,httpOptions));
    console.log(x);
    return x;


  }

  async editReview(id : number, text : string, game :string){
    let token = localStorage.getItem("token");
    let httpOptions = {
        headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
        })
    };

    let reviewDTO = {
      Text : text,
      Game : game
    }


    let x = await lastValueFrom(this.http.put<any>(domain + "api/Reviews/EditReview/" + id,reviewDTO,httpOptions));
    console.log(x);
    return x;



  }

  async upvoteReview(id : number){
    let token = localStorage.getItem("token");
    let httpOptions = {
        headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
        })
    };
    let x = await lastValueFrom(this.http.put<any>(domain + "api/Reviews/UpvoteReview/" + id,null,httpOptions));
    console.log(x);
    return x;


  }
  async getUsername(){
    let token = localStorage.getItem("token");
    let httpOptions = {
        headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
        })
    };
    let x = await lastValueFrom(this.http.get<any>(domain + "api/Users/GetUsername",httpOptions));
    console.log(x);
    return x.name;
  }

}
