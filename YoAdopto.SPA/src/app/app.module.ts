import { WelcomeComponent } from './welcome/welcome.component';
import { AppRouters } from './app.routes';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CollapseModule } from 'ngx-bootstrap';

@NgModule({
   declarations: [
      AppComponent,
      WelcomeComponent,
      NavbarComponent
   ],
   imports: [
      BrowserModule,
      CollapseModule.forRoot(),
      AppRouters
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
