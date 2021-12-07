import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GenerateComponent } from './generate/generate.component';
import { HomeComponent } from './home/home.component';
import { RedeemComponent } from './redeem/redeem.component';

const routes: Routes = [
  {  path: '', redirectTo:'/home', pathMatch:'full', },
  {  path: 'home', component: HomeComponent ,},
  {  path: 'generate', component: GenerateComponent,  },
  {  path: 'redeem', component: RedeemComponent,  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
