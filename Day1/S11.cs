using System;
//There are two kinds of rentals i.e. Books and Movies.
public abstract class Rental {
    private DateTime rentDate;
    private DateTime dueDate;
    private double rentalFee;
    protected abstract double getOverduePenaltyRate();
    public bool isOverdue() {
        DateTime now=DateTime.Today;
		return DateTime.Compare(dueDate, now) < 0;
    }
    public double getTotalFee() {
        return isOverdue() ? getOverduePenaltyRate()*rentalFee : rentalFee;
    }
}
public class BookRental : Rental {
    private string bookTitle;
    private string author;
    private static double PENALTY_RATE=1.2;
    protected override double getOverduePenaltyRate() {
        return PENALTY_RATE;
    }
}
public class MovieRental : Rental {
    private string movieTitle;
    private int classification;
    private static double PENALTY_RATE=1.3;
    protected override double getOverduePenaltyRate() {
        return PENALTY_RATE;
    }
}
