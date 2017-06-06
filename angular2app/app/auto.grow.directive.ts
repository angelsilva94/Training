import {Directive,ElementRef,Renderer} from '@angular/core'
@Directive({
    selector: '[autoGrow]',
    host: {
        '(focus)': 'onfocus()',
        'blur':'onBlur()'
    }
})
export class AutoGrowDirective{
    constructor(private el: ElementRef,private render: Renderer) {
        
    }
    onFocus() {
        this.render.setElementStyle(this.el.nativeElement, 'witdh', '200');
    }
    onBlur() {
        this.render.setElementStyle(this.el.nativeElement, 'witdh', '120');
    }
}