import { FormControl } from '@angular/forms';




export class UserNameValidators {
  static cannotContainSpaces(control: FormControl) {
    if (control.value.indexOf(' ') >= 0) {
      console.log('entre');
      return { cannotContainSpaces: true };
    }
    return null;
  }
  static shouldBeUnique(control: FormControl){
      return new Promise((resolve, reject) => {
            setTimeout(() => {
                if (control.value === 'bob') {
                    resolve({shouldBeUnique: true});
                }else {
                    resolve(null);
                }
            }, 1000);
        });
    }
}
