using System;
using System.Collections.Generic;
class RentalNotFoundException : Exception {
    //...
}
public class BookRental {
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
public class BookRentals {
    private List<BookRental> rentals;
    public string getCustomerName(string rentalId) {
        int rentalIdx = getRentalIdxById(rentalId);
        return rentals[rentalIdx].customerName;
    }
    public void deleteRental(string rentalId) {
        rentals.RemoveAt(getRentalIdxById(rentalId));
    }
    private int getRentalIdxById(string rentalId) {
		int i=0;
        foreach (BookRental rental in rentals ) {
            if (rental.id.Equals(rentalId)) 
                return i;
			i++;
        }
        throw new RentalNotFoundException();
    }
}
