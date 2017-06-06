import { AuthorService } from './author.service';
import { Component } from '@angular/core';

@Component({
    selector: 'authors',
    template: `
        <h2>Authors</h2>
        {{title}}
        <ul>
            <li *ngFor='let author of authors'>{{author}}</li>
        </ul>
    `,
    providers:[AuthorService]
})
export class AuthorsComponent{
    title = 'The title of the Authors Page';
    authors;
    constructor(authorService:AuthorService) {
        this.authors = authorService.getAuthors();
    }
}