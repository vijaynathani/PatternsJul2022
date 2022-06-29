using System;
using System.Collections.Generic;
class RentalNotFoundException : Exception {
    //...
}
class BookRental {
    public string id {
		get { return id; }
		set { this.id = value;}
	}
    public string customerName {
		get { return customerName; }
		set { customerName = value; }
	}
    //...
}

//Improve the following code
class BookRentals {
    private List<BookRental> rentals;
    public string getCustomerName(string rentalId) {
        foreach (BookRental rental in rentals) {
            if (rental.id.Equals(rentalId)) {
                return rental.customerName;
            }
        }
        throw new Exception("Rental not found");
    }
    public void deleteRental(string rentalId) {
        foreach (BookRental rental in rentals) {
            if (rental.id.Equals(rentalId)) {
                rentals.Remove(rental);
                return;
            }
        }
        throw new Exception("Rental not found");
    }
}
