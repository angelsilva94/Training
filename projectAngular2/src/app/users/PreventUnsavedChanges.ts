import { AddUserComponent } from './addUser.component';
import { CanDeactivate } from '@angular/router';
import { Injectable } from '@angular/core';


@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<AddUserComponent> {

  canDeactivate(component: AddUserComponent) {
    if (component.hasChanges()) {
      return confirm('Are you sure?');
    }
    return true;
  }

}
