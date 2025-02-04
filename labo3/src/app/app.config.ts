import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),  // Cette ligne doit être ajoutée
    provideHttpClient()
  ]
};
export class Song{

  constructor(
      public name : string,
      public duration : number
  ){}

}
