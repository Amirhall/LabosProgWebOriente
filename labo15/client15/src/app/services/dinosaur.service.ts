import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Dinosaur } from '../models/dinosaur';
import { Zookeeper } from '../models/zookeeper';

const domain = "https://localhost:7298/";

@Injectable({
  providedIn: 'root'
})
export class DinosaurService {

  constructor(public http : HttpClient) { }

  async postDinosaur(name : string, specie : string, id : number) : Promise<Dinosaur>{

    // À compléter
    let dinosaurDTO = {
      name : name,
      specie: specie,
      zookeeperID : id
    
    };
    let x = await lastValueFrom(this.http.post<any>(domain + "api/Dinosaurs/PostDinosaur"  ,dinosaurDTO));
    
    // À retirer
    return x;

  }

  async getDinosaurs() : Promise<Dinosaur[]>{

    let x = await lastValueFrom(this.http.get<Dinosaur[]>(domain + "api/Dinosaurs/GetDinosaur"));
    console.log(x);
    return x;

  }

  async deleteDinosaur(id : number){

    // À compléter

  }

  async postZookeeper(name : string) : Promise<Zookeeper>{

    // À compléter
    let x = await lastValueFrom(this.http.post<any>(domain + "api/Zookeepers/PostZookeeper"  ,new Zookeeper(0,name)));
    console.log(x);

    // À retirer
    return x;

  }

  async getZookeepers() : Promise<Zookeeper[]>{

    let x = await lastValueFrom(this.http.get<any>(domain + "api/Zookeepers/GetZookeeper"));
    console.log(x);
    return x;

  }

  async deleteZookeeper(id : number){
    let x = await lastValueFrom(this.http.delete<any>(domain + "api/Zookeepers/DeleteZookeeper/" +id));
    console.log(x);

    // À retirer
    return x;

  }

  async postIncident(description : string, nbCasualties : number, ids : number[]) : Promise<void>{

    // À compléter
    console.log("involved dinos: " + ids)
    let incidentDTO = {
      description : description,
      nbCasualties: nbCasualties,
      involvedDinosaursID : ids
    
    };
    let x = await lastValueFrom(this.http.post<any>(domain + "api/Incidents/PostIncident"  ,incidentDTO));
    console.log(x);
  }

}
