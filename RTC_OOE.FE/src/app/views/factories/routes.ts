import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./factories.component').then(m => m.FactoriesComponent),
    data: {
      title: $localize`Factories`
    }
  }
];

