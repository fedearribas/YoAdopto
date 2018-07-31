import { Router } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isCollapsed = true;
  constructor(public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router) { }

  ngOnInit() {
    console.log( this.authService.currentUser);

  }

  logout() {
    this.authService.userToken = null;
    this.authService.currentUser = null;
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.alertify.message('Has cerrado sesión');
    this.router.navigate(['']);
    this.isCollapsed = true;
  }

}
