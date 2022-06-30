class Department {
	public static readonly Department Account;
	public static readonly Department Marketing;
	public static readonly Department CustomerServices;
	static Department() {
		Account = new Department("Account");
		Marketing = new Department("Marketing");
		CustomerServices = new Department("Customer Services ");
	}
	private string departmentName;
	private Department(string departmentName){
		this.departmentName = departmentName;
	}
	public string getDepartmentName(){
		return departmentName;
	}
}
