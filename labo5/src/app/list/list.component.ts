import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CardComponent } from '../card/card.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  standalone: true,
  imports: [CommonModule,RouterModule,CardComponent],
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  characters : string[] = ["bebe","butters","clyde","craig","eric","kenny","kyle","nichole","stan","tolkien","wendy"];

  constructor() { }

  ngOnInit() {
  }


}
