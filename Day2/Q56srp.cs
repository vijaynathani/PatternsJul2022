using System;
using System.Collections.Generic;
/* This application is about restaurants. Initially we created a
 * Restaurant class to represent a restaurant account and
 * includes information such as its
 *      name, access password, tel and fax number, address.
 * The class is like:
 * class Restaurant { string name, password, telNo, faxNo, address;}
 *
 * Later, the following requirements are added in sequence:
 * 1. After initial registration, the restaurant account is assigned an
 *    activation code by the system. Only after the user enters the
 *    activation code, the account will become activated.
 *    Until then, the account is inactive and login is not allowed.
 * 2. If the user would like to change the fax number of the account,
 *    the new fax number will not take effect immediately
 *    (the existing fax number will remain in effect). Instead,
 *    the account is assigned an activation code by the system.
 *    Only after the user enters the activation code, the new fax number
 *    will take effect.
 * 3. A restaurant can be marked as in a certain category
 *    (e.g., Chinese restaurant, Portuguese restaurant and etc.).
 *    A category is identified by a category ID.
 * 4. The user can input the holidays for the restaurant.
 * 5. The user can input the business hours for the restaurant.
 *
 * After implementing all these five requirements, the class has grown
 * significantly and become quite complicated as shown below. Our task
 * now is to implement the five requirements above in separate classes,
 * leaving the original simple Restaurant class unchanged.
 */
class Restaurant {
    string name;
    string password;
    string telNo;
    string faxNo;
    string address;
    string verificationCode;
    bool isActivated;
    string faxNoToBeConfirmed;
    bool isThereFaxNoToBeConfirmed = false;
    string catId;
    List<DateTime> holidays;
    List<DateTime> businessSessions;
    void activate(string verificationCode) {
        isActivated =(this.verificationCode.Equals(verificationCode));
        if (isActivated && isThereFaxNoToBeConfirmed){
            faxNo = faxNoToBeConfirmed;
            isThereFaxNoToBeConfirmed = false;
        }
    }
    void setFaxNo(string newFaxNo) {
        faxNoToBeConfirmed = newFaxNo;
        isThereFaxNoToBeConfirmed = true;
        isActivated = false;
    }
    bool isInCategory(string catId) {
        return this.catId.Equals(catId);
    }
    void addHoliday(int year, int month, int day) {
        //...
    }
    void removeHoliday(int year, int month, int day) {
    	//...
    }
    bool addBusinessSession(int fromHour, int fromMin,
                int toHour, int toMin) {
        //...
		return false;
    }
    bool isInBusinessHour(DateTime time) {
        //...
		return false;
    }
    List<DateTime> getAllHolidays() {
        return holidays;
    }
    List<DateTime> getAllBusinessSessions() {
        return businessSessions;
    }
}
