import { Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { IndexComponent } from './index/index.component';

export const routes: Routes = [
    {path: "", redirectTo: "/index", pathMatch: "full"},
    {path: "index", component: IndexComponent},
    {path: "list", component: ListComponent, pathMatch: "full"},
    {path: "details/:characterName", component: DetailsComponent, pathMatch: "full"},

];
