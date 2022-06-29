using System;
using System.Collections.Generic;
class BookRental { //..
	public bool isOverdue() { //..
		return false;
	}
	public string toString() { //..
		return null;
	}
}
//Improve the code
class BookRentals {
    List<BookRental> rentals;
    public int countRentals() {
        return rentals.Count;
    }
    BookRental getRentalAt(int i) {
        return rentals[i];
    }
    void printOverdueRentals() {
        int i;
        for (i=0; i<countRentals(); i++) {
            BookRental rental = getRentalAt(i);
            if (rental.isOverdue()
                      // && ... //Complex condition
               )
                Console.WriteLine(rental.toString());
        }
    }
    int countOverdueRentals() {
        int i, count;
        count=0;
        for (i=0; i<countRentals(); i++)
            if (getRentalAt(i).isOverdue() 
                      //&& ... //Same complex condition
               )
                count++;
        return count;
    }
}
