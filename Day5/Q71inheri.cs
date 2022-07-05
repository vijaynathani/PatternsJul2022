using System;
using System.Collections.Generic;
//Point out and remove the problem in code below.
public class Course { //..
	public string getTitle() { return null; }
}
public class CourseCatalog : Dictionary<string,Course> {
    public void addCourse(Course c) {
        Add(c.getTitle(), c);
    }
    public Course findCourse(string title) {
		Course r;
        TryGetValue(title, out r);
		return r;
    }
    public int countCourses() {
        return Count;
    }
}

