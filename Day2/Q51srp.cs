class Department{
    public const int Account =0;
    public const int Marketing = 1;
    public const int CustomerServices = 2;
    int departmentCode;
    public Department(int departmentCode){
        this.departmentCode = departmentCode;
    }
    public string getDepartmentName(){
        switch (departmentCode){
        case Account:
            return "Account";
        case Marketing:
            return "Marketing";
        case CustomerServices:
            return "Customer Services";
        }
		return "";
    }
}
