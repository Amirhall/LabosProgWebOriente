import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MagicCard } from '../models/magic-card';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { MagicService } from '../services/magic.service';

@Component({
  selector: 'app-by-type',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './by-type.component.html',
  styleUrl: './by-type.component.css'
})
export class ByTypeComponent implements OnInit{

  inputType : string = "";
  cards : MagicCard[] = [];

  nameSuggestions : string[] = [];


  constructor(public http : HttpClient, public route : ActivatedRoute,public magic : MagicService){}

  ngOnInit(): void {
    // Si un paramètre de route a été reçu, l'intégrer au champ de recherche
    let type : string | null = this.route.snapshot.paramMap.get("type");
    if(type != null){
      this.inputType = type;
    }
  }

  async searchByType() : Promise<void>{
    if(this.inputType == "") return;

    // Requête par type
    let x = await this.magic.searchByType(this.inputType);
    console.log(x);

    this.cards = [];
    for (let c of x.cards) {
      this.cards.push(new MagicCard(c.name, c.manaCost, c.imageUrl, c.type));
    }

    // Suggestions de noms à partir des cartes obtenues
    let i = 0;
    while(this.nameSuggestions.length < 15 && this.nameSuggestions.length < this.cards.length){
      if(!this.nameSuggestions.includes(this.cards[i].name)) this.nameSuggestions.push(this.cards[i].name);
      i++;
    }
  }

  chooseType(type : string) : void{
    this.inputType = type;
  }
  async chooseName(name : string) : Promise<void>{
    this.nameSuggestions = [];

    // Requête par nom ET par type
    let x = await this.magic.searchByNameAndType(name,this.inputType);
    console.log(x);

    this.cards = [];
    for (let c of x.cards) {
      this.cards.push(new MagicCard(c.name, c.manaCost, c.imageUrl, c.type));
    }
  }

}
