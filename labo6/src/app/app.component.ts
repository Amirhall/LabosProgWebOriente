import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { MagicService } from './services/magic.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
  constructor(public magic : MagicService){}

}
