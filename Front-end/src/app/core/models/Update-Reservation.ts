export interface UpdateReservation {
    reservationId: number|null,
    roomId: number|null,
    customerId: number|null,
    guestName: string,
    checkInDate: Date,
    checkOutDate: Date
}

