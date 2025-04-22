import { HttpClient } from '@angular/common/http';
import { Injectable, Signal, signal, WritableSignal } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Review } from '../models/review';

const domain = "https://localhost:7033/api/";

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(public http : HttpClient) { }
  private usernameSignal : WritableSignal<string|null> = signal(null);
  private roleSignal : WritableSignal<string[]> = signal([]);
  readonly username : Signal<string|null> = this.usernameSignal.asReadonly();
  readonly roles : Signal<string[]> = this.roleSignal.asReadonly();

  setUsername(username : string | null){
    this.usernameSignal.set(username);
}

setRoles(roles : string[]){
    this.roleSignal.set(roles);
}

  async register(username : string, password : string, passwordConfirm : string){

    let registerDTO = {
      username : username,
      password : password,
      passwordConfirm : passwordConfirm
    };

    let x = await lastValueFrom(this.http.post<any>(domain + "Users/Register", registerDTO));
    console.log(x);

  }

  async login(username : string, password : string){

    let loginDTO = {
      username : username,
      password : password
    };

    let x = await lastValueFrom(this.http.post<any>(domain + "Users/Login", loginDTO));
    console.log(x);

    localStorage.setItem("token", x.token);
    localStorage.setItem("roles", JSON.stringify(x.roles));
    localStorage.setItem("pseudo", JSON.stringify(x.pseudo));
    this.setUsername(x.pseudo);
    this.setRoles(x.roles);
    

  }

  async logout(){


    localStorage.removeItem("token");


  }

  async getReviews() : Promise<Review[]>{

    let x = await lastValueFrom(this.http.get<Review[]>(domain + "Reviews/GetReview"));
    console.log(x);

    return x;

  }

  async postReview(text : string) : Promise<Review>{

    let reviewDTO = { text : text };

    let x = await lastValueFrom(this.http.post<any>(domain + "Reviews/PostReview", reviewDTO));
    console.log(x);

    return x;

  }

  async deleteReview(id : number){

    let x = await lastValueFrom(this.http.delete<any>(domain + "Reviews/DeleteReview/" + id));
    console.log(x);

  }

}
