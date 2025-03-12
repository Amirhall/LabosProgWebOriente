import { Injectable } from '@angular/core';
import { Character } from '../models/character';
import { lastValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VincibleService {

  constructor(public http : HttpClient) { }

  async getCharacter(name: string) : Promise<Character|null>{
    
    let x = await lastValueFrom(this.http.get<any>("http://localhost:5254/api/Characters/GetCharacterByName/" + name));
    console.log(x);
    return new Character(x.name,x.age,x.superpowers,x.imageUrl,x.isAlive);
    
  }

  async getCharacters(power : string) : Promise<Character[]>{

    let x = await lastValueFrom(this.http.get<any>("http://localhost:5254/api/Characters/GetCharactersByPower/" + power));
    console.log(x);
    let characters = [];
    for(let c of x){
      characters.push(new Character(c.name, c.age, c.superpowers, c.imageUrl, c.isAlive))
    }
    return characters;

  }

}
