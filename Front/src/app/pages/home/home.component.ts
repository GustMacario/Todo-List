import { Router } from '@angular/router';
import { HomeService } from './../../services/home.service';
import { Component, OnInit } from '@angular/core';
import { todoModel } from 'src/app/types/TodoModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  public todos: todoModel[] = [];
  public task: any = {
    id: '',
    name: '',
    description: '',
    expectedDate: '',
    status: '',
    priority: 0,
    createdAt: '',
    updatedAt: '',
    delayed: false,
  };
  public showModal: boolean = false;
  selectedOption: any;
  selectStatus = [
    { name: 'A fazer', status: 1 },
    { name: 'Bloqueado', status: 0 },
    { name: 'Em progresso', status: 2 },
    { name: 'Concluído', status: 3 },
  ];

  constructor(private homeService: HomeService, private router: Router) {}
  ngOnInit(): void {
    this.GetTodoTasks();
    
  }

  GetTodoTasks() {
    this.homeService.GetTodoTasks().subscribe((data: any) => {
      this.todos = data.resultado;
      this.todos.forEach((todo) => {
        todo.createdAt = this.formatDate(todo.createdAt);
        todo.updatedAt = this.formatDate(todo.updatedAt);
        todo.expectedDate = this.formatDate(todo.expectedDate);
      });
    });
  }

  GetTodoById(todoId: string) {
    this.homeService.GetTodoById(todoId).subscribe((data: any) => {
      this.task.id = data.resultado.todoId;
      this.task.name = data.resultado.name;
      this.task.description = data.resultado.description;
      this.task.delayed = data.resultado.delayed;
      this.task.expectedDate = this.formatDate(data.resultado.expectedDate);
      switch (data.resultado.status) {
        case 1:
          this.task.status = 'Bloqueado';
          break;
        case 2:
          this.task.status = 'Em progresso';
          break;
        case 3:
          this.task.status = 'Concluído';
          break;
        default:
          this.task.status = 'A fazer';
      }
      this.task.priority = data.resultado.priority;
      this.task.createdAt = this.formatDate(data.resultado.createdAt);
      this.task.updatedAt = this.formatDate(data.resultado.updatedAt);
    });
  }

  saveChangesModal(status: any, todoId: any) {
    this.homeService
      .EditTodoTaskStatus(status, todoId)
      .subscribe((data: any) => {
        this.showModal = false;
        this.selectedOption = undefined;
        this.GetTodoTasks();
      });
  }

  deleteTask(todoId: any) {
    console.log(todoId);
    this.homeService.DeleteTodoTask(todoId).subscribe((data: any) => {
      this.showModal = false;
      this.GetTodoTasks();
    });
  }

  openModal(todoId: any) {
    this.showModal = true;
    this.GetTodoById(todoId.todoId);
  }

  closeModal() {
    this.showModal = false;
    this.selectedOption = undefined;
    this.GetTodoTasks();
  }

  dataChanged(event: any) {
    this.selectedOption = event;
  }


  formatDate(dateString: string): string {
    if (!dateString) return '';

    const date = new Date(dateString);
    const day = date.getDate();
    const month = date.getMonth() + 1;
    const year = date.getFullYear() % 100;

    const formattedDay = day < 10 ? '0' + day : day;
    const formattedMonth = month < 10 ? '0' + month : month;
    const formattedYear = year < 10 ? '0' + year : year;

    return `${formattedDay}/${formattedMonth}/${formattedYear}`;
  }
}
