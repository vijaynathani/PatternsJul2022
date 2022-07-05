using System;
class Date { //..
}
/* This application is concerned with training courses.
 * A course has a title, a fee and a list of sessions. However,
 * sometimes a course can consist of several modules, each of which is a
 * course. For example, there may be a compound course "Fast track to
 * becoming a web developer" which consists of three modules: a course
 * named "HTML", a course named "FrontPage" and a course named "Flash".
 * It is possible for a module to consist of some other modules.
 * If a course consists of modules, its fee and schedule are totally
 * determined by that of its modules and thus it will not maintain
 * its list of sessions.
 * Point out and remove the code smells in the code */
class Session {
    Date date;
    int startHour;
    int endHour;
    public int getDuration() {
        return endHour-startHour;
    }
}
class Course {
    string courseTitle;
    Session[] sessions;
    double fee;
    Course[] modules;
    Course(string courseTitle, double fee, Session[] sessions) {
        //...
    }
    Course(string courseTitle, Course[] modules) {
        //...
    }
    string getTitle() {
        return courseTitle;
    }
    double getDuration() {
        double duration=0;
        if (modules==null)
            for (int i=0; i<sessions.Length; i++)
                duration += sessions[i].getDuration();
        else
            for (int i=0; i<modules.Length; i++)
                duration += modules[i].getDuration();
        return duration;
    }
    double getFee() {
        if (modules==null)
            return fee;
        else {
            double totalFee = 0;
            for (int i=0; i<modules.Length; i++)
                totalFee += modules[i].getFee();
            return totalFee;
        }
    }
    void setFee(int fee) {
    if (modules==null)
        this.fee = fee;
    else
        throw new ArgumentException (
				"Please set the fee of each module one by one");
    }
}
