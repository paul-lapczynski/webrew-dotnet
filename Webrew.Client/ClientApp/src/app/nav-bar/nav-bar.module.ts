import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatToolbarModule, MatButtonModule, MatIconModule, MatSidenavModule } from '@angular/material';

@NgModule({
    declarations: [NavBarComponent],
    imports: [CommonModule, FlexLayoutModule, MatToolbarModule, MatButtonModule, MatIconModule, MatSidenavModule],
    exports: [NavBarComponent]
})
export class NavBarModule {}
