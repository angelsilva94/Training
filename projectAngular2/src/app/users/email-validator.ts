import { FormControl } from '@angular/forms';

export class EmailValidator {
  private  emailP = '/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/';
  static validateEmail(control: FormControl) {
    if (!control.value.match(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/)) {
      console.log('ENTRE');
      return { 'invalidEmail': true };
    } else {
      console.log('correcto');
      return null;
    }
  }
}
