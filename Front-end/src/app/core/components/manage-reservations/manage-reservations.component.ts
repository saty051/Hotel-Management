import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Reservation } from '../../models/Reservation';
import { HotelAppDBService } from '../../service/hotel-app-db.service';

@Component({
  selector: 'app-manage-reservations',
  templateUrl: './manage-reservations.component.html',
  styleUrls: ['./manage-reservations.component.css']
})
export class ManageReservationsComponent {

  allReservations : Reservation[] = [];

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }

  ngOnInit()
  {
    this.service.getAllReservations().subscribe
    (
      (data) =>
      {
        this.allReservations = data;
        console.log(this.allReservations);
      }
    );
  }

  Delete(id : number)
  {
    this.service.deleteReservationById(id).subscribe(
      {
        next:(response)=>{
          console.log("Deleted Successfully");

        }
        
      }
    )
  }

  Update(id:number)
  {
    this.route.navigate(['/updateReservation',id]);
  }

}
