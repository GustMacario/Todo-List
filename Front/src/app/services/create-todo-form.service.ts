import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateTodoRequest } from '../types/CreateTodoRequest';

@Injectable({
  providedIn: 'root'
})
export class CreateTodoFormService {
  url = "http://localhost:5286/api/";
  httpOptions = {
    headers: new HttpHeaders({"Content-Type": "application/json"})
  }
  
  constructor(private http: HttpClient) { }

  createTodo(model: CreateTodoRequest){
    return this.http.post(this.url + 'ToDo/CreateToDo', model); 
  }
}
