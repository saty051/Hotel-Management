import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AddReservation } from 'src/app/core/models/Add-Reservation';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css']
})
export class AddReservationComponent {
  addReservation : AddReservation = {
    roomId: null,
    customerId: null,
    guestName: null,
    checkInDate: null,
    checkOutDate: null
  };

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }
  
  Add()
  {
    console.log(this.addReservation);
    this.service.addReservation(this.addReservation).subscribe(
      {
        next:(response)=>
        {
          console.log("Added Successfully");
          alert("Added Successfully");
          this.route.navigate(['/reservations']);
        }
      }
    );
    
  }  
}
