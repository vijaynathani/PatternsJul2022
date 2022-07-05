using System;
using System.Collections.Generic;
//EmployeeList does not want to inherit the addNode method.
//Employee is not a Node.
public class Node {
	private Node nextNode;
	public Node getNextNode() {
		return nextNode;
	}
	public void setNextNode(Node nextNode) {
		this.nextNode = nextNode;
	}
}
public class LinkList {
	private Node firstNode;
	public void AddNode(Node newNode) {
		//...
	} 
	public Node getFirstNode() {
		return firstNode;
	}
}
public class Employee {
	string employeeId;
	string name;
	//...
} 
public class EmployeeNode : Node {
	readonly Employee employee;
	public Employee getEmployee() { return employee; }
	public EmployeeNode(Employee e) { employee = e; }
}
public class EmployeeList {
	LinkList list;
	public void addEmployee(Employee employee) {
		list.AddNode(new EmployeeNode(employee));
	}
	public Employee getFirstEmployee() {
		return ((EmployeeNode)list[0]).getEmployee();
	}
	//...
}
