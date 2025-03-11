import { Component, OnInit } from '@angular/core';
import { MagicCard } from '../models/magic-card';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { MagicService } from '../services/magic.service';

@Component({
  selector: 'app-by-name',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './by-name.component.html',
  styleUrl: './by-name.component.css'
})
export class ByNameComponent implements OnInit{

  inputName : string = "";
  cards : MagicCard[] = [];

  typeSuggestions : string[] = [];


  constructor(public http : HttpClient, public route : ActivatedRoute,public magic : MagicService){}

  ngOnInit(): void {
    // Si un paramètre de route a été reçu, l'intégrer au champ de recherche
    let name : string | null = this.route.snapshot.paramMap.get("name");
    if(name != null){
      this.inputName = name;
    }
  }

  async searchByName() : Promise<void>{
    if(this.inputName == "") return;

    // Recherche par nom
    let x = await this.magic.searchByName(this.inputName);
    console.log(x);

    this.cards = [];
    for (let c of x.cards) {
      this.cards.push(new MagicCard(c.name, c.manaCost, c.imageUrl, c.type));
    }

    // Suggestions de types en fonction des cartes obtenues
    let i = 0;
    while(this.typeSuggestions.length < 15 && i < this.cards.length){
      if(!this.typeSuggestions.includes(this.cards[i].type)) this.typeSuggestions.push(this.cards[i].type);
      i++;
    }
  }

  chooseName(name : string) : void{
    this.inputName = name;
  }

  async chooseType(type : string) : Promise<void>{
    this.typeSuggestions = [];

    // Requête par nom ET par type
    let x = await this.magic.searchByNameAndType(this.inputName, type);
    console.log(x);

    this.cards = [];
    for (let c of x.cards) {
      this.cards.push(new MagicCard(c.name, c.manaCost, c.imageUrl, c.type));
    }
  }

}
