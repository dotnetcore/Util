import { Component, ElementRef, OnInit, HostListener} from '@angular/core';
import { Router } from '@angular/router';
//import { AuthService } from './core/auth.service';


@Component({
  selector: 'ui-toolbar-user',
  templateUrl: './home/user'
})

export class ToolbarUserComponent implements OnInit {

  isOpen: boolean = false;
  currentUser = null;

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

  logout() {
      this.router.navigate(['/login']);
  }

  ngOnInit() {
  }

  constructor(private _elementRef: ElementRef,
    private router: Router) {
  }

  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }
}
