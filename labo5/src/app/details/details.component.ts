import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Character } from '../models/character';
import { lastValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './details.component.html',
  styleUrl: './details.component.css'
})
export class DetailsComponent implements OnInit {
  characterName: string | null = null;
  characterDetails: Character | null = null;

  constructor(public http : HttpClient,public route : ActivatedRoute) { }

  async ngOnInit() {
    this.characterName = this.route.snapshot.paramMap.get("characterName");
    if (this.characterName == null) {
      this.characterName = "kenny";

    };
    console.log(this.characterName);
    let x = await lastValueFrom(this.http.get<any>("https://spapi.dev/api/characters?search=" + this.characterName));
    console.log(x.data[0]);
    let data = x.data[0];

    this.characterDetails = new Character(data.name,data.age,data.occupation,data.grade,data.episodes.length);
    console.log(this.characterDetails);
    
    
  }
  

}
