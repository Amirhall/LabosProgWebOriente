import { Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { ByTypeComponent } from './by-type/by-type.component';
import { ByNameComponent } from './by-name/by-name.component';

export const routes: Routes = [
    {path:"", redirectTo:"/index", pathMatch:"full"},
    {path:"index", component:IndexComponent},
    {path:"byType", component:ByTypeComponent},
    {path:"byName", component:ByNameComponent},
    {path:"byType/:type", component:ByTypeComponent},
    {path:"byName/:name", component:ByNameComponent}
];
