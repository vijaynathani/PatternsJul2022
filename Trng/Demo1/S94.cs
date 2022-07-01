using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1;
class Course
{
    string courseId;
    string title;
    int fee;
    Session[] sessions;
}
class Session
{
    DateOnly date;
    int startHour;
    int endHour;
}
interface ICourseTables
{
    void Add(CourseTable a);
    CourseTable Get(string courseId);
    IEnumerable<CourseTable> GetAllCoursesOfHigherDuration(int durationHours);
}

class CourseTable
{
    string courseId;
    string title;
    int fee;
}
class SessionTable
{
    string courseId;
    int sessionId;
    DateOnly date;
    int startHour, endHour;
}
