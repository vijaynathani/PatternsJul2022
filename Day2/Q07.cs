using System;
using System.Collections.Generic;
class Account { //..
}
//improve code
class Restaurant : Account {
    //the string "Rest" is concated with the restaurant ID to
    //form the key.
    const string RestaurantIDText = "Rest";

    string website;

    string addr_cn; //address in Chinese.
    string addr_en; //address in English.

    //the restaurant would like to update its fax # with this. After it is
    //confirmed, it will be stored in Account. Before that, it is stored
    //here.
    string numb_newfax;
    bool has_NewFax = false;

    //a list of holidays.
    List<DateTime> Holiday; 

    //id of the category this restaurant belongs to.
    string catId;

    //a list of business session. Each business session is an array
    //of two times. The first time is the start time. The second time
    //is the end time. The restaurant is open for business in each
    //session.
    List<DateTime> BsHour; //Business hour
    //...
    //y: year.
    //m: month.
    //d: date.
    void addHoliday(int y,int m,int d){
        if(y<1900) y+=1900;
        DateTime aHoliday = (new DateTime(y,m,d,0,0,0));
        Holiday.Add(aHoliday);
    }

    public bool addBsHour(int fromHr, int fromMin, int toHr, int toMin){
        int fMin = fromHr*60 + fromMin; //start time in minutes.
        int tMin = toHr*60 + toMin; //end time in minutes.
        //make sure both times are valid and the start time is earlier
        //than the end time.
        if(fMin >= 0 && fMin <= 1440 && tMin >= 0 && 
                tMin <=1440 && fMin < tMin){
            BsHour.Add(new DateTime(1900,1,1, fromHr, fromMin,0));
            BsHour.Add(new DateTime(1900,1,1, toHr, toMin,0));
            return true;
        } else {
            return false;
        }
    }
}
