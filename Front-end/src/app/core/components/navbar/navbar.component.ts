import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class AppNavbarComponent {
  constructor(private router: Router) {}

  navigateTo(route: string) 
  {
    this.router.navigate([route.toLowerCase()]);
  }
}