import { NgModule } from '@angular/core';
//Angular模块
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";

@NgModule({
    exports: [
        CommonModule, FormsModule, RouterModule, HttpClientModule
    ]
})
export class FrameworkModule {
}