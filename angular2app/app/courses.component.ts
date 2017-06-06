import { AutoGrowDirective } from './auto.grow.directive';
import { CourseService } from './course.service';
import { Component } from '@angular/core';

@Component({
    selector: 'courses',
    template: `
        <h2>Courses</h2>
        {{title}}
        <input type="text" autoGrow />
        <ul>
            <li *ngFor='let course of courses'>{{course}}</li>
        </ul>
    `,
    providers: [CourseService],//dependency injection aqui le decimos que tipo de objeto es
    directives:[AutoGrowDirective]
})

export class CoursesComponent{
    constructor(courseService:CourseService) {//dependency injection a un objecto cualquiera
        this.courses = courseService.getCourses();
    }
    title = 'The title of courses page';
    courses;
}