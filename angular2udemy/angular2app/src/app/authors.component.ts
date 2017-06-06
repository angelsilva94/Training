import { AuthorService } from './authors.service';
import { Component } from '@angular/core';
@Component({
  selector: 'author',
  template: `
    <h2>{{title}}</h2>
    <ul>
      <li *ngFor='let author of authors'>{{author}} </li>
    </ul>
  `,
  // providers:[AuthorService]
})

export class AuthorsComponent{
  authors;
  title = 'Title of the Authors page';
  constructor(authorService: AuthorService) {
    this.authors = authorService.getAuthors();
  }
}
