import { CityComponent } from "./city/city.component";
import { Routes } from "@angular/router";

export const appRoutes: Routes = [
    { path: "city", component: CityComponent },
    { path: "**", redirectTo: "city", pathMatch: "full" },
]