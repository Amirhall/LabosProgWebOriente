import { CommonModule } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PictureService } from './services/picture.service';



@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  @ViewChild("myFileInput", {static : false}) pictureInput ?: ElementRef;

  pictureIds : number[] = []; // Pas besoin de model pour les pictures ... les ids suffisent ...

  constructor(public pictureService : PictureService){}

  async ngOnInit() {
    this.pictureIds = await this.pictureService.getPictureIds();
  }

  async updateDisplay(){
    //this.pictureIds = await ...;
    this.pictureIds = await this.pictureService.getPictureIds();
  }

  async postPicture(){
    if(this.pictureInput == undefined){
      console.log("Input HTML non chargé.");
      return;
  }

  // On récupère le premier (ou le seul) fichier dans l'<input> !
  
  
  let formData = new FormData();

  for(let i = 0; i < this.pictureInput.nativeElement.files.length; i++){
    console.log(this.pictureInput.nativeElement.files[i]);
    let file = this.pictureInput.nativeElement.files[i];
    formData.append("monImage" + i, file, file.name);
  }

    
    await this.pictureService.postPicture(formData);
    
  }

  async deletePicture(id : number){

    await this.pictureService.deletePicture(id);
    this.pictureIds.splice(this.pictureIds.indexOf(id), 1);

  }

}
