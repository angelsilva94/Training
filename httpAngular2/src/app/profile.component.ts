import { ProfileService } from './profile.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'profile',
  templateUrl: 'profile.component.html'

})
export class ProfileComponent implements OnInit {

  constructor(private _profileService: ProfileService) {}
  ngOnInit() {
    this._profileService.getUser('angelsilva94').subscribe(user => console.log(user));
  }
}
