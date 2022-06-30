using System;
using System.Collections.Generic;
public class Restaurant {
    public string name {
		get { return name; }
	}
    string password;
    string telNo;
    string faxNo;
	public void setFaxNo(string faxno) { this.faxNo = faxNo; }
    string address;
}
public abstract class RestaurantTaskActivator {
    string verificationCode;
    protected Restaurant restaurant;
    public bool tryToActivate(string restName, string verificationCode) {
        if (restName.Equals(restaurant.name) &&
            this.verificationCode.Equals(verificationCode)) {
            doSomethingToRestaurant();
            return true;
        }
        return false;
    }
    public abstract void doSomethingToRestaurant();
}
class RestaurantActivator : RestaurantTaskActivator {
    public override void doSomethingToRestaurant() {
        //add restaurant to the system;
    }
}
class FaxNoActivator : RestaurantTaskActivator {
    string newFaxNo;
    public override void doSomethingToRestaurant() {
        restaurant.setFaxNo(newFaxNo);
    }
}
class RestaurantTaskActivators {
    RestaurantTaskActivator[] activators;
    void activate(string restName, string verificationCode) {
        for (int i = 0; i < activators.Length; i++) {
            if (activators[i].tryToActivate(restName, verificationCode)) {
                //remove activator[i] from activators;
                return;
            }
        }
    }
}
class Category {
    string catId;

}
class Holidays {
    List<DateTime> holidays;
    void addHoliday(int year, int month, int day) {
        //...
    }
    void removeHoliday(int year, int month, int day) {
        //...
    }
    List<DateTime> getAllHolidays() {
        return holidays;
    }
}
class BusinessSessions {
    List<DateTime> businessSessions;
    bool addBusinessSession(int fromHour, int fromMin,
        int toHour, int toMin) {
        //...
		return false;
    }
    bool isInBusinessHour(DateTime time) {
        //...
		return false;
    }
    List<DateTime> getAllBusinessSessions() {
        return businessSessions;
    }
}
class RestaurantSystem {
    Restaurant[] restaurants;
    RestaurantTaskActivators restaurantTaskActivators;
    Dictionary<Restaurant,Category[]> mapRestIdToCatagories;
    Dictionary<Restaurant,Holidays> mapRestIdToHolidays;
    Dictionary<Restaurant,BusinessSessions> mapRestIdToBusinessSessions;
}

