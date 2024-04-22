import { Router } from '@angular/router';
import { CreateTodoFormService } from '../../../services/create-todo-form.service';
import { Component, OnInit } from '@angular/core';
import { todoModel } from 'src/app/types/TodoModel';

@Component({
  selector: 'app-create-todo-form',
  templateUrl: './create-todo-form.component.html',
  styleUrls: ['./create-todo-form.component.css']
})
export class CreateTodoFormComponent {
  public task: any = {
    name: '',
    description: '',
    expectedDate: new Date(),
    priority: '',
  };
  currentDate: Date = new Date();
  constructor(private homeService: CreateTodoFormService, private router: Router) {}
  
  ngOnInit(): void {}

  createTask(task: any) {
    switch (task.priority) {
      case 'Baixa':
        this.task.priority = 0;
        break;
      case 'Média':
        this.task.priority = 1;
        break;
      case 'Alta':
        this.task.priority = 2;
        break;
    }
    this.homeService.createTodo(this.task).subscribe((data: any) => {
      this.router.navigate(['/']);
    });
  }

  goBack() {
    this.router.navigate(['/']);
  }
}


