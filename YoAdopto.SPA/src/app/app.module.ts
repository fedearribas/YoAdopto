import { RegisterComponent } from './auth/register/register.component';
import { AlertifyService } from './_services/alertify.service';
import { AuthService } from './_services/auth.service';
import { WelcomeComponent } from './welcome/welcome.component';
import { AppRouters } from './app.routes';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CollapseModule } from 'ngx-bootstrap';
import { LoginComponent } from './auth/login/login.component';
import { FormsModule, ReactiveFormsModule } from '../../node_modules/@angular/forms';
import { HttpClientModule } from '../../node_modules/@angular/common/http';
import { JwtHelperService, JwtModule } from '../../node_modules/@auth0/angular-jwt';
import { BsDropdownModule } from 'ngx-bootstrap';

export function getAccessToken(): string {
  return localStorage.getItem('token');
}

export const jwtConfig = {
  tokenGetter: getAccessToken,
  whitelistedDomains: ['localhost:5000']
};

@NgModule({
   declarations: [
      AppComponent,
      WelcomeComponent,
      NavbarComponent,
      LoginComponent,
      RegisterComponent
   ],
   imports: [
      BrowserModule,
      FormsModule,
      ReactiveFormsModule,
      HttpClientModule,
      CollapseModule.forRoot(),
      AppRouters,
      JwtModule.forRoot({
        config: jwtConfig
      }),
      BsDropdownModule.forRoot()
   ],
   providers: [
     AuthService,
     AlertifyService,
     JwtHelperService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
