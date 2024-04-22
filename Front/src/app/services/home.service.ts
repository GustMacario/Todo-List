import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateTodoRequest }  from '../types/CreateTodoRequest';

@Injectable({
  providedIn: 'root'
})
export class HomeService {
  url = "https://localhost:44352/api/";
  httpOptions = {
    headers: new HttpHeaders({"Content-Type": "application/json"})
  }
  
  constructor(private http: HttpClient) { }

  createTodo(model: CreateTodoRequest){
    return this.http.post(this.url + 'ToDo/CreateToDo', model); 
  }

  GetTodoById(todoId: string){
    return this.http.get(this.url + `ToDo/GetToDoById/${todoId}`); 
  }

  GetTodoTasks(){
    return this.http.get(this.url + 'ToDo/GetToDoTasks'); 
  }

  EditTodoTaskStatus(status: number, todoId: string) {
    console.log(status, todoId);
    const urlWithQueryParams = `${this.url}ToDo/EditToDoTaskStatus/${todoId}?status=${status}`;
    return this.http.put(urlWithQueryParams, null); 
  }

  DeleteTodoTask(todoId: string){
    return this.http.delete(this.url + `ToDo/DeleteToDoTask/${todoId}`); 
  }
}
