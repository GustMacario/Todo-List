import { TestBed } from '@angular/core/testing';

import { CreateTodoFormService } from './create-todo-form.service';

describe('CreateTodoFormService', () => {
  let service: CreateTodoFormService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreateTodoFormService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
