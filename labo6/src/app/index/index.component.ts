import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MagicService } from '../services/magic.service';


@Component({
  selector: 'app-index',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './index.component.html',
  styleUrl: './index.component.css'
})
export class IndexComponent {



  constructor(public router : Router,public magic : MagicService){}

  chooseType(type : string) : void{
    // Aller dans le composant byType si un type a été cliqué
    this.router.navigate(["/byType", type]);
  }

  chooseName(name : string) : void{
    // Aller dans le composant byName si un nom a été cliqué
    this.router.navigate(["/byName", name]);
  }

}
