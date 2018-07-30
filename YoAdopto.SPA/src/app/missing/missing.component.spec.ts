/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MissingComponent } from './missing.component';

describe('MissingComponent', () => {
  let component: MissingComponent;
  let fixture: ComponentFixture<MissingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MissingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MissingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
