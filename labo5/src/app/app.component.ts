import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterModule, IndexComponent, ListComponent, DetailsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

}
