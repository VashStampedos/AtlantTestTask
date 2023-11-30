import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { DetailsComponent } from './details/details.component';
import { StorekeeperComponent } from './storekeeper/storekeeper.component';

export const routes: Routes = [
    {path: "details", component:DetailsComponent},
    {path:"storekeepers", component:StorekeeperComponent},
  
];
