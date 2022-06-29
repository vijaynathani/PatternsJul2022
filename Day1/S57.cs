using System;
class Date { //...
}
class Payment { //...
}

class Student {
    string studentId;
    string name;
    Date dateOfBirth;
}
class Enrollment {
    string studentId;
    string courseCode;
    Date enrollDate;
    Payment payment;
}
class Enrollments {
    Enrollment[] enrollments;
    void enroll(string studentId, string courseCode, Date enrollDate,
            Payment payment) {
        Enrollment enrollment = new Enrollment(studentId, courseCode, ...);
        //add enrollment to enrollments;
    }
    void unenroll(string studentId, string courseCode) {
        //...
    }
}
class StudentManagementSystem {
    Student[] students;
    Enrollments enrollments;
}
