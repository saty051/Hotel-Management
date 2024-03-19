import { TestBed } from '@angular/core/testing';

import { HotelAppDBService } from './hotel-app-db.service';

describe('HotelAppDBService', () => {
  let service: HotelAppDBService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HotelAppDBService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
