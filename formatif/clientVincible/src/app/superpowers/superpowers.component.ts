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

  async searchCharacters(){
    // À compléter
  }

}
