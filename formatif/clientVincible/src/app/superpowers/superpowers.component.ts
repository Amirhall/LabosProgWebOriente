import { Component, OnInit } from '@angular/core';
import { Character } from '../models/character';
import { VincibleService } from '../services/vincible.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-superpowers',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './superpowers.component.html',
  styleUrl: './superpowers.component.css'
})
export class SuperpowersComponent{

  powerInput : string = "";
  characters : Character[] = [];

  constructor(public vincible : VincibleService, public route : ActivatedRoute){}

  ngOnInit() {
    let power = this.route.snapshot.paramMap.get("power");
    if (power != null){
      this.powerInput = power;
      this.searchCharacters(power);
    }
  }

  

  async searchCharacters(power: string){
    this.characters = [];
    this.characters  = await this.vincible.getCharacters(power);
    console.log(this.characters);
  }

}
