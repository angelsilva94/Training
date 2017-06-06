import { Input,Component } from '@angular/core';


@Component({
    selector: 'zippy',
    template: `
        <div class="zippy">
            <div 
                class="zippy-title"
                (click)="clicked()">
                {{title}}
                <i 
                    class="pull-right glyphicon"
                    [ngClass]="{
                        'glyphicon-chevron-up':isClicked,
                        'glyphicon-chevron-down':!isClicked       
                             
                    }">
                    
                </i>
            </div>
            <div class="zippy-content" *ngIf="isClicked">
                <ng-content></ng-content>
            </div>
        </div>
    `
})

export class ZippyComponent {
    @Input() title;
    isClicked = false;
    clicked() {
        this.isClicked = !this.isClicked;
    }
}