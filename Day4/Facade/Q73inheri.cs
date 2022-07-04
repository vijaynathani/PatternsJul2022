using System;
using System.Collections.Generic;
/* Suppose that in general a teacher can teach many students. However, 
 * a graduate student can be taught by a graduate teacher only. 
 * Point out and remove the problem in the code:
 */

class Student {
    string studentId;
    //...
}
class Teacher {
    string teacherId;
    List<Student> studentsTaught;
	//...
    public string getId() {
        return teacherId;
    }
    public void addStudent(Student student) {
        studentsTaught.Add(student);
    }
}
class GraduateStudent : Student {
	//...
}
class GraduateTeacher : Teacher {
	//...
}
