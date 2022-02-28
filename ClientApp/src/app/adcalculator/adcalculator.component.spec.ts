import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdcalculatorComponent } from './adcalculator.component';

describe('AdcalculatorComponent', () => {
  let component: AdcalculatorComponent;
  let fixture: ComponentFixture<AdcalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdcalculatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdcalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
