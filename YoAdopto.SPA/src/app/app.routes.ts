import { PublicationDetailComponent } from './_shared/publication/publication-detail/publication-detail.component';
import { PublicationsResolver } from './_resolvers/publications.resolver';
import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {WelcomeComponent} from './welcome/welcome.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { MissingComponent } from './missing/missing.component';
import { MissingContainerComponent } from './missing/missing-container/missing-container.component';

const routes: Routes = [
  {path: '', component: WelcomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'perdidos', component: MissingComponent,
    children: [
      {path: '', component: MissingContainerComponent, data: {publicationTypeId: 1},
        resolve: { publications: PublicationsResolver }
      },
      {path: ':id', component: PublicationDetailComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRouters {}
