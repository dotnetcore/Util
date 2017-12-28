import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'ui-header',
  templateUrl: './home/header'
})
export class HeaderComponent implements OnInit {


  isFullscreen: boolean = false;
  showNavigation: boolean = true;
  showLoading: boolean;

  @Output() sidenavOpens = new EventEmitter<boolean>();

  showComponent() {
    this.sidenavOpens.emit(this.showNavigation);
    this.showNavigation = !this.showNavigation;
  }

  fullScreen() {
    
  }

  ngOnInit() {
  }

}
