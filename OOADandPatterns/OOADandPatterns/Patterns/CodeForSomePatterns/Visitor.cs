using System;
using System.Collections.Generic;

namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal abstract class Employee
    {
        protected Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public abstract void Visit(EmployeeVisitor v);
    }

    internal class SalariedEmployee : Employee
    {
        public SalariedEmployee(string name, double salary) : base(name)
        {
            Salary = salary;
        }

        public double Salary { get; set; }

        public override void Visit(EmployeeVisitor v)
        {
            v.Visit(this);
        }
    }

    internal class HourlyEmployee : Employee
    {
        public HourlyEmployee(string name, int hours)
            : base(name)
        {
            Hours = hours;
        }

        public int Hours { get; set; }

        public override void Visit(EmployeeVisitor v)
        {
            v.Visit(this);
        }
    }

    internal interface EmployeeVisitor
    {
        void Visit(HourlyEmployee e);
        void Visit(SalariedEmployee e);
    }

    internal class VisitorReport : EmployeeVisitor
    {   //With Design Pattern
        public void Visit(HourlyEmployee e)
        {
            var s = "Hourly employee " + e.Name +
                    " worked for " + e.Hours + " hours";
            Console.WriteLine(s);
        }

        public void Visit(SalariedEmployee e)
        {
            var s = "Employee" + e.Name + " has salary " +
                    e.Salary;
            Console.WriteLine(s);
        }

        public void Print(List<Employee> emps)
        {
            foreach (var e in emps)
                e.Visit(this);
        }
    }

    internal class ReportWithoutDesignPattern
    {
        public void Print(List<Employee> emps)
        {
            foreach (var e in emps)
            {
                var s = "";
                if (e is SalariedEmployee)
                {
                    var e1 = e as SalariedEmployee;
                    s = "Employee" + e1.Name + " has salary" +
                        e1.Salary;
                }
                else
                {
                    var e1 = e as HourlyEmployee;
                    s = "Hourly employee " + e1.Name +
                        " worked for " + e1.Hours + " Hours";
                }
                Console.WriteLine(s);
            }
        }
    }
}