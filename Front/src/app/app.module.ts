import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HomeComponent } from './pages/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreateTodoFormComponent } from './pages/createTodoForm/create-todo-form/create-todo-form.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CreateTodoFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    FormsModule      
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
