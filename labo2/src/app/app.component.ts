import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { VideoGame } from './models/videogame';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  // Servira plus tard
  videoGames: VideoGame[] = [];
  trucsQueJaime: string[] = ["coincer mon doigt dans une porte", "le bowling", "le prof"];
  userAge: number = 22;
  n: number = 0;
  theme: string = "light";
  userName: string = "";
  selectBackgroundColor: string = "lightcyan";

  vgName: string = "";
  vgNbPlayers: number = 0;
  vgReleased: boolean = false;
  vgGenre: string = "";
  vgMode: string = "";

  count(): void {
    if (this.n != 10) {
      this.n++;
    }
  }
  changeTheme(): void {
    this.theme = (this.theme == "light") ? this.theme = "dark" : this.theme = "light";

  }
  saluer(): void {
    alert("Salut " + this.userName + " !");
  }
  creerUnJeu(): void {
    let genres = this.vgGenre.split(",");
    if (this.vgName != "" || this.vgNbPlayers != 0 || this.vgGenre != "" || this.vgMode != "") {
      let newGame: VideoGame = new VideoGame(this.vgName, this.vgNbPlayers, this.vgReleased, genres, this.vgMode);
      this.videoGames.push(newGame);
    }



  }
}



