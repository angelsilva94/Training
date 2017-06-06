import { Component,Input,Output,EventEmitter } from '@angular/core'


@Component({
    selector: 'vote',
    template: `
    <div style="width:20px;">
        <i class="glyphicon glyphicon-menu-up" (click)=upVote() [class.highlighted]="myVote==1"></i>
        <span>{{myVote}}</span>
        <i class="glyphicon glyphicon-menu-down"(click)=downVote() [class.highlighted]="myVote==-1"></i>
    </div>
    `,
    styles: [`
        .glyphicon-menu-up {
            color: #ccc;
            cursor: pointer;
        }
        .glyphicon-menu-down {
            color: #ccc;
            cursor: pointer;
        }
        .highlighted {
            color: orange;
        }
    `]
    
})
export class VoteComponent{
    @Input() voteCount=0;
    @Input() myVote=0;
    @Output() vote=new EventEmitter();
    upVote() {
        if (this.myVote == 1)
            return;
        this.myVote++;

        
    }
    downVote() {
       if (this.myVote == -1)
            return;
        this.myVote--;
        
    }
}