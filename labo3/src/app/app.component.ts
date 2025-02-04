import { Component } from '@angular/core';
import { Song } from './models/song';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(public http : HttpClient){}
  
  artistName : string = "";
  genre : string = "";
  apiKey : string = "9a8a3facebbccaf363bb9fd68fa37abf";
  errorArtistMessage : string = "";
  errorGenreMessage : string = "";
  similarArtists : string[] = [];
  topSongs : Song[] = [];
  getSimilarArtistCompleted : boolean = false;
  getTopSongCompleted : boolean = false;

  async getSimilarArtists(){
    this.getSimilarArtistCompleted = false;
    try{
      this.similarArtists = [];
      let x = await lastValueFrom(this.http.get<any>(`https://ws.audioscrobbler.com/2.0/?method=artist.getsimilar&artist=${this.artistName}&api_key=${this.apiKey}&format=json`));
      console.log(x);
      for(let a of x.similarartists.artist){
        this.similarArtists.push(a.name);
      }
      this.errorArtistMessage = "";
      this.getSimilarArtistCompleted = true;
    }
    catch(error){
      console.log(error);
      this.errorArtistMessage = "Aucun album n'a été trouvé.";
      this.artistName = "";

    }
   


  }

  async getTopSongs(){
    this.getTopSongCompleted = false;
    try{
      this.topSongs = [];
    let x = await lastValueFrom(this.http.get<any>(`https://ws.audioscrobbler.com/2.0/?method=tag.gettoptracks&tag=${this.genre}&api_key=${this.apiKey}&format=json`));
    for(let s of x.tracks.track){
      console.log(s.artist.name)
      this.topSongs.push(new Song(s.name,s.artist.name, s.duration));
    }
    this.errorGenreMessage = "";
    this.getTopSongCompleted = true;
    }
    catch(error){
      this.errorArtistMessage = "Réessayez avec un genre qui existe";
      this.genre = "";

    }





  }
  

}

