import { HomeComponent } from './pages/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateTodoFormComponent } from './pages/createTodoForm/create-todo-form/create-todo-form.component';

const routes: Routes = [

  { path: '', component: HomeComponent },
  
  { path: 'CreateTodo', component: CreateTodoFormComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
