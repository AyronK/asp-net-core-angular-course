import { TestBed, inject } from '@angular/core/testing';

import { MakesService } from './makes.service';

describe('MakesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MakesService]
    });
  });

  it('should be created', inject([MakesService], (service: MakesService) => {
    expect(service).toBeTruthy();
  }));
});
