import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Hotel } from '../../models/Hotel';
import { HotelAppDBService } from '../../service/hotel-app-db.service';

@Component({
  selector: 'app-manage-hotels',
  templateUrl: './manage-hotels.component.html',
  styleUrls: ['./manage-hotels.component.css']
})
export class ManageHotelsComponent {
  allHotels : Hotel[] = [];

  constructor(private service: HotelAppDBService, private route : Router)
  {

  }

  ngOnInit()
  {
    this.service.getAllHotels().subscribe
    (
      (data) =>
      {
        this.allHotels = data;
        console.log(this.allHotels);
      }
    );
  }

  Delete(id : number)
  {
    this.service.deleteHotelById(id).subscribe(
      {
        next:(response)=>{
          console.log("Deleted Successfully");

        }
        
      }
    )
  }

  Update(id:number)
  {
    this.route.navigate(['/updateHotel',id]);
  }
}
