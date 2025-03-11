import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MagicService {

  nameExamples : string[] = ["Moonshaker Cavalry", "Sword of Once and Future", "Geological Appraiser", "Beseech the Mirror", "Up the Beanstalk"];
  typeExamples : string[] = ["instant", "land", "beast", "dragon", "goblin", "artifact"];
  requestCount : number = 0;
  constructor(public http : HttpClient) { }

  async searchByName(name : string) : Promise<any>{
    // Recherche par nom
    let x = await lastValueFrom(this.http.get<any>(`https://api.magicthegathering.io/v1/cards?name=${name.toLowerCase()}`));
    this.requestCount++;
    return x;

  }
  async searchByType(type : string) : Promise<any>{
    // Recherche par nom
    let x = await lastValueFrom(this.http.get<any>(`https://api.magicthegathering.io/v1/cards?type=${type}`));
    this.requestCount++;
    return x;

  }
  async searchByNameAndType(name : string,type : string) : Promise<any>{
    // Recherche par nom
    let x = await lastValueFrom(this.http.get<any>(`https://api.magicthegathering.io/v1/cards?name=${name.toLowerCase()}&type=${type}`));
    this.requestCount++;
    return x;

  }


}
