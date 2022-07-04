using System;
using System.Collections.Generic;
abstract class Student {
    string studentId;
    //...
}
class NonGraduateStudent : Student {
}
class GraduateStudent : Student {
}
abstract class Teacher {
    string teacherId;
    protected List<Student> studentsTaught;
	//...
    public string getId() {
        return teacherId;
    }
}
class NonGraduateTeacher : Teacher {
    public void addStudent(NonGraduateStudent student) {
        studentsTaught.Add(student);
    }
}
class GraduateTeacher : Teacher {
    public void addStudent(Student student) {
        studentsTaught.Add(student);
    }
}
