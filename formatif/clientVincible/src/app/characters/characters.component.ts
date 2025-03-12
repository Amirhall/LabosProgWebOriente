import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Character } from '../models/character';
import { VincibleService } from '../services/vincible.service';
import { ActivatedRoute, RouterModule } from '@angular/router';

@Component({
  selector: 'app-characters',
  standalone: true,
  imports: [CommonModule,RouterModule,FormsModule],
  templateUrl: './characters.component.html',
  styleUrl: './characters.component.css'
})
export class CharactersComponent {

  constructor(public vincible : VincibleService,public route : ActivatedRoute){}

  character : Character | null = null;
  characterInput: string = "";
  favoriteslist: Character[] = [];

  addToFavs(){
    if(this.character == null) return;
    alert(this.character.name + " ajouté(e) aux favoris !");
    let favData = localStorage.getItem("fav");
    if(favData != null){
      this.favoriteslist = JSON.parse(favData);
      this.favoriteslist.push(this.character);
      localStorage.setItem("fav", JSON.stringify(this.favoriteslist));

    }


    // À compléter
  }
  async getCharacter(name: string){
    this.character = null;
    let x = await this.vincible.getCharacter(name);
    if(x != null){
      this.character = x;
      
    }
    console.log(this.character);
  }

}
