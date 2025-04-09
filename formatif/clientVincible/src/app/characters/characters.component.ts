import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Character } from '../models/character';
import { VincibleService } from '../services/vincible.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-characters',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './characters.component.html',
  styleUrl: './characters.component.css'
})
export class CharactersComponent {

  constructor(public vincible : VincibleService){}

  character : Character | null = null;

  addToFavs(){
    if(this.character == null) return;
    alert(this.character.name + " ajouté(e) aux favoris !");

    // À compléter
  }

}
