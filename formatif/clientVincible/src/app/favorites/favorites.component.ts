import { Component, OnInit } from '@angular/core';
import { Character } from '../models/character';
import { CommonModule } from '@angular/common';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-favorites',
  standalone: true,
  imports: [CommonModule, TranslateModule,FormsModule],
  templateUrl: './favorites.component.html',
  styleUrl: './favorites.component.css'
})
export class FavoritesComponent implements OnInit{

  characters : Character[] = [];

  constructor(){}

  ngOnInit(){
   let favData= localStorage.getItem("fav");
    if(favData != null){
      this.characters = JSON.parse(favData);
      console.log(this.characters);
    }
  }

  emptyFavs(){

  }

}
