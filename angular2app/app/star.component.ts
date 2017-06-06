import { Component, EventEmitter, Output, Input } from '@angular/core';

@Component({
    selector: 'star',
    template: `
        <i 
            class="glyphicon glyphicon-star"
            [ngClass]="{
                'glyphicon-star-empty':!clicked,
                'glyphicon-star':clicked                
            }"
            (click)="click()">
        
        </i>
    `,
    // inputs: ['clicked'],
    // outputs:['change']
    // [class.glyphicon-star-empty]="!clicked"
    //         [class.glyphicon-star]="clicked",
})

export class StarComponent{
    @Input() clicked = false;
    @Output() change = new EventEmitter();
    click() {
        this.clicked = !this.clicked;
        this.change.emit({newValue:this.clicked});
        console.log("click");
    }
}