using System;
using System.Collections.Generic;
public class Course { //..
	public string getTitle() { return null; }
}
public class CourseCatalog {
	Dictionary<string,Course> courses = new Dictionary<string,Course>();
    public void addCourse(Course c) {
        courses.Add(c.getTitle(), c);
    }
    public Course findCourse(string title) {
		Course r;
        courses.TryGetValue(title, out r);
		return r;
    }
    public int countCourses() {
        return courses.Count;
    }
}

