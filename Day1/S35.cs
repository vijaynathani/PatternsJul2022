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

interface RentalProcessor {
	void process(BookRental rental);
}

class BookRentals {
	List<BookRental> rentals;
	int countRentals() {
		return rentals.Count;
	}
	BookRental getRentalAt(int i) {
        return rentals[i];
	}
	void processOverdueRentals(RentalProcessor processor) {
		for (int i=0; i<countRentals(); i++) {
			BookRental rental = getRentalAt(i);
			if (rental.isOverdue() 
				//&& ... //A complex condition
			   )
				processor.process(rental);
		}
	}
	class Printing : RentalProcessor {
		public void process(BookRental rental) {
			Console.WriteLine(rental.toString());
		}
	}
	void printOverdueRentals() {
		processOverdueRentals(new Printing());
	}
	class CountRentals : RentalProcessor {
		public int count;
		public void process(BookRental rental) {
			count++;
		}
	}
	int countOverdueRentals() {
		CountRentals cr=new CountRentals();
		processOverdueRentals(cr);
		return cr.count;
	}
}
