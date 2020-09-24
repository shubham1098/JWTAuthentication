import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoadingSpinnerComponent } from './loading-spinner/loading-spinner.component';
import { PlaceholderDirective } from './placeholder/placeholder.directive';

@NgModule({
  declarations: [
    LoadingSpinnerComponent,
    PlaceholderDirective
  ],
  imports: [CommonModule],
  exports: [
    LoadingSpinnerComponent,
    CommonModule,
    PlaceholderDirective
  ],
})
export class SharedModule {}
