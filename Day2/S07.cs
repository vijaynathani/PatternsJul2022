using System;
using System.Collections.Generic;
class Account { //..
}
class TimeRange { //..
	public TimeRange(int fromHour,int fromMinute,int toHour,int toMinute) {
		//..
	}
}

class Restaurant : Account {
    private class TimeRange {
        private int fromHour, toHour, fromMinutes, toMinutes;
        public TimeRange(int fromHour, int toHour,
            int fromMinutes, int toMinutes) {
            //...
        }
    }
    const string RestaurantIDText = "Rest";
    string website;
    string chineseAddress;
    string englishAddress;
    string newFaxNumberToBeConfirmed;
    bool has_NewFax = false;
    List<DateTime> listOfHolidays;
    string catId;
    List<TimeRange> BusinessHours;
    //...
    private const int BASE_YEAR=1900,
        HOURS_IN_A_DAY=24, MINUTES_IN_AN_HOUR=60;
    void addHoliday(int year,int month,int day){
        if(year<BASE_YEAR) year+=BASE_YEAR;
        DateTime aHoliday = new DateTime(year,month,day,0,0,0);
        listOfHolidays.Add(aHoliday);
    }
    private int getMinutesFromMidnight(int hours, int minutes) {
        return hours * MINUTES_IN_AN_HOUR + minutes;
    }
    private bool isMinutesWithinOneDay(int minutes) {
        return (minutes >= 0) &&
            (minutes <= HOURS_IN_A_DAY * MINUTES_IN_AN_HOUR );
    }
    public bool addBsHour(int fromHour, int fromMinute,
            int toHour, int toMinute){
        int fromInMinutes = getMinutesFromMidnight(fromHour, fromMinute);
        int toInMinutes = getMinutesFromMidnight(toHour,toMinute);
        bool timesValid = isMinutesWithinOneDay(fromInMinutes) &&
                            isMinutesWithinOneDay(toInMinutes) &&
                            fromInMinutes < toInMinutes;
        if (timesValid)
            BusinessHours.Add(new TimeRange(fromHour,fromMinute,toHour,toMinute));
        return timesValid;
    }
}
