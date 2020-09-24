import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { SharedModule } from '../shared/shared.module';
import { HomePageComponent } from './homepage.component';
import { HomePageRoutingModule } from './homepage.routing.module';


@NgModule({
  declarations: [HomePageComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([{ path: '', component: HomePageComponent }]),
    SharedModule,
    HomePageRoutingModule
  ]
})
export class HomePageModule {}
