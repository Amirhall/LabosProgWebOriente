import { Component, OnInit } from '@angular/core';
import { Character } from '../models/character';
import { CommonModule } from '@angular/common';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-favorites',
  standalone: true,
  imports: [CommonModule, TranslateModule],
  templateUrl: './favorites.component.html',
  styleUrl: './favorites.component.css'
})
export class FavoritesComponent implements OnInit{

  characters : Character[] = [];

  constructor(){}

  ngOnInit(){

  }

  emptyFavs(){

  }

}
