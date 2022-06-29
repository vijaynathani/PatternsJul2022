using System;
//There are two kinds of rentals i.e. Books and Movies. Improve the code
public class BookRental {
    string bookTitle;
    string author;
    DateTime rentDate;
    DateTime dueDate;
    double rentalFee;
    public bool isOverdue() {
        DateTime now=DateTime.Today;
		return DateTime.Compare(dueDate, now) < 0;
    }
    public double getTotalFee() {
        return isOverdue() ? 1.2*rentalFee : rentalFee;
    }
}
public class MovieRental {
    string movieTitle;
    int classification;
    DateTime rentDate;
    DateTime dueDate;
    double rentalFee;
    public bool isOverdue() {
        DateTime now=DateTime.Today;
		return DateTime.Compare(dueDate, now) < 0;
    }
    public double getTotalFee() {
        return isOverdue() ? 1.3*rentalFee : rentalFee;
    }
}
