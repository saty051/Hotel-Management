import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ManageHotelsComponent } from './core/components/manage-hotels/manage-hotels.component';
import { ManageRoomsComponent } from './core/components/manage-rooms/manage-rooms.component';
import { ManageEmployeesComponent } from './core/components/manage-employees/manage-employees.component';
import { ManageCustomersComponent } from './core/components/manage-customers/manage-customers.component';
import { ManageReservationsComponent } from './core/components/manage-reservations/manage-reservations.component';
import { NavbarComponent } from './core/components/navbar/navbar.component.spec';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { UpdateCustomerComponent } from './core/components/manage-customers/update-customer/update-customer.component';
import { AddCustomerComponent } from './core/components/manage-customers/add-customer/add-customer.component';
import { AddEmployeeComponent } from './core/components/manage-employees/add-employee/add-employee.component';
import { UpdateEmployeeComponent } from './core/components/manage-employees/update-employee/update-employee.component';
import { AddReservationComponent } from './core/components/manage-reservations/add-reservation/add-reservation.component';
import { UpdateReservationComponent } from './core/components/manage-reservations/update-reservation/update-reservation.component';
import { AddHotelsComponent } from './core/components/manage-hotels/add-hotels/add-hotels.component';
import { UpdateHotelComponent } from './core/components/manage-hotels/update-hotel/update-hotel.component';
import { AddRoomComponent } from './core/components/manage-rooms/add-room/add-room.component';
import { UpdateRoomComponent } from './core/components/manage-rooms/update-room/update-room.component';
@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ManageHotelsComponent,
    ManageRoomsComponent,
    ManageEmployeesComponent,
    ManageCustomersComponent,
    ManageReservationsComponent,
    UpdateCustomerComponent,
    AddCustomerComponent,
    AddEmployeeComponent,
    UpdateEmployeeComponent,
    AddReservationComponent,
    UpdateReservationComponent,
    AddHotelsComponent,
    UpdateHotelComponent,
    AddRoomComponent,
    UpdateRoomComponent,
    AddRoomComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    RouterModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
