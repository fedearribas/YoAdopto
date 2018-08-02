import { PublicationDetailComponent } from './_shared/publication/publication-detail/publication-detail.component';
import { PublicationsResolver } from './_resolvers/publications.resolver';
import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {WelcomeComponent} from './welcome/welcome.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { MissingComponent } from './missing/missing.component';
import { MissingContainerComponent } from './missing/missing-container/missing-container.component';
import { PublicationDetailResolver } from './_resolvers/publication-detail.resolver';
import { PublicationFormComponent } from './_shared/publication/publication-form/publication-form.component';

const routes: Routes = [
  {path: '', component: WelcomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'perdidos', component: MissingComponent,
    runGuardsAndResolvers: 'always',
    children: [
      {path: '', component: MissingContainerComponent, data: {publicationTypeId: 1},
        resolve: { publications: PublicationsResolver }
      },
      {path: 'new', component: PublicationFormComponent, data: {publicationTypeId: 1}},
      {path: ':id', component: PublicationDetailComponent,
        resolve: {publication: PublicationDetailResolver}
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRouters {}
