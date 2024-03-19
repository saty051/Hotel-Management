import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Reservation } from 'src/app/core/models/Reservation';
import { HotelAppDBService } from 'src/app/core/service/hotel-app-db.service';

@Component({
  selector: 'app-update-reservation',
  templateUrl: './update-reservation.component.html',
  styleUrls: ['./update-reservation.component.css']
})
export class UpdateReservationComponent {
  id: number = 0;
updateReservation : Reservation = {
  reservationId: 0,
  roomId: 0,
  customerId: 0,
  guestName: "",
  checkInDate: new Date,
  checkOutDate: new Date
  }
  constructor(private service : HotelAppDBService, private router : ActivatedRoute, private route:Router) {}
  ngOnInit()
  {
    this.id = Number(this.router.snapshot.paramMap.get('id'));
    console.log(this.id);

    if(this.id)
    {
      this.service.getReservationById(this.id).subscribe
      (
        {
          next:(response)=>this.updateReservation = response
        }
      )
    }
  }

  Update()
  {
    this.service.updateReservation(this.updateReservation).subscribe
    (
      {
        next:(response)=>
        {
          console.log("Updated Successfully");
          alert("Updated Successfully");
          this.route.navigate(['/reservations']);
        }
      }
    )
  }
}
