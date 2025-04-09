import { Injectable } from '@angular/core';
import { Character } from '../models/character';
import { lastValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VincibleService {

  constructor(public http : HttpClient) { }

  async getCharacter() : Promise<Character|null>{

    // Personnage hardcodé si vous n'arrivez pas à compléter la fonction. NE SUPPRIMEZ PAS CETTE LIGNE DE CODE TROP VITE !
    return new Character("Dupli-Kate", null, ["Réplication"], "http://localhost:5254/api/Characters/GetPicture/6", true);
    
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
