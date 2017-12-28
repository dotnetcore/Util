import { Component, ElementRef, OnInit, HostListener } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'ui-toolbar-notification',
  templateUrl: './home/notification'
})

export class ToolbarNotificationComponent {

  isOpen: boolean = false;
  notifications = [];


  @HostListener('document:click', ['$event', '$event.target'])
  onClick(event: MouseEvent, targetElement: HTMLElement) {
    if (!targetElement) {
      return;
    }

    const clickedInside = this._elementRef.nativeElement.contains(targetElement);
    if (!clickedInside) {
      this.isOpen = false;
    }
  }

  constructor(private _elementRef: ElementRef,
    private router: Router) {
  }

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }

}
