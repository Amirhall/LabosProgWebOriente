import { Routes } from '@angular/router';
import { CharactersComponent } from './characters/characters.component';
import { SuperpowersComponent } from './superpowers/superpowers.component';
import { FavoritesComponent } from './favorites/favorites.component';

export const routes: Routes = [
    {path:"", redirectTo:"/characters", pathMatch:"full"},
    {path:"characters", component:CharactersComponent},
    {path:"superpowers", component:SuperpowersComponent},
    {path:"superpowers/:power", component:SuperpowersComponent},
    {path:"favorites", component:FavoritesComponent}
];
