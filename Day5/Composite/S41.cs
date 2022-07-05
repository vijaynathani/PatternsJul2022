using System;
class Date {//...
}

class Session {
    Date date;
    int startHour;
    int endHour;
    public int getDuration() {
        return endHour-startHour;
    }
}
abstract class Course {
    string courseTitle;
    public Course(string courseTitle) {
        //...
    }
    public string getTitle() {
        return courseTitle;
    }
    public abstract double getFee();
    public abstract double getDuration();
}
class SimpleCourse : Course {
    Session[] sessions;
    double fee;
    public SimpleCourse(string courseTitle, double fee, 
			Session[] sessions) : base(courseTitle) {
        //...
    }
    public override double getFee() {
        return fee;
    }
    public override double getDuration() {
        int duration=0;
        for (int i=0; i<sessions.Length; i++) {
            duration += sessions[i].getDuration();
        }
        return duration;
    }
    void setFee(int fee) {
        this.fee = fee;
    }
}
class CompoundCourse : Course { 
	Course[] modules;
    CompoundCourse(string courseTitle, Course[] modules) 
			: base(courseTitle) {
        //...
    }
    public override double getFee() {
        double totalFee = 0;
        for (int i=0; i<modules.Length; i++) {
            totalFee += modules[i].getFee();
        }
        return totalFee;
    }
    public override double getDuration() {
        double duration=0;
        for (int i=0; i<modules.Length; i++) {
            duration += modules[i].getDuration();
        }
        return duration;
    }
}
