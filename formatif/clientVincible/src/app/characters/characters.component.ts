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
    

    let favoris = [];
    
    // Tenter d'aller récupérer les anciens favoris dans le stockage local
    
    // Si les anciens favoris existent bel et bien, remplacer favoris par le stockage local
    let favData = localStorage.getItem("fav");
    if(favData != null){
      favoris = JSON.parse(favData);
    }

    // Ajouter le personnage dans les favoris
    favoris.push(this.character);

    // Sauvegarder le stockage local
    localStorage.setItem("fav", JSON.stringify(favoris));

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
