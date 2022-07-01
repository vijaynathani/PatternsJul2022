class Date { //..
	public int getTime() { //...
	}
}

interface Schedule {
    int getDurationInDays();
    void print();
}
class WeeklySchedule : Schedule {
    int noWeeks;
    Date fromDate;
    Date toDate;
    public int getDurationInDays() {
        return noWeeks;
    }
    public void print() {
        //...
    }
}
class RangeSchedule : Schedule {
    Date fromDate;
    Date toDate;
    public int getDurationInDays() {
        int milliSecondsInOneDay = 24*60*60*1000;
        return (int)((toDate.getTime()-fromDate.getTime()) /
                    milliSecondsInOneDay);
    }
    public void print() {
        //...
    }
}
class ListSchedule : Schedule {
    Date[] dateList;
    public int getDurationInDays() {
        return dateList.Length;
    }
    public void print() {
    	//...
    }
}
class Course {
    string courseTitle;
    Schedule schedule;
	//...
    public int getDurationInDays() {
        return schedule.getDurationInDays();
    }
    public void printSchedule() {
        schedule.print();
    }
}
