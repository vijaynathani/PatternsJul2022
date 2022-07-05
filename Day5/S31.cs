using System;
class UserAccount {
	UserType userType;
	string id;
	string name;
	string password;
	public DateTime dateOfLastPasswdChange;
	public UserType getType() {
		return userType;
	}
	public bool checkPassword(string password) { bool r =false;
		//...
		return r;
	}
} 
class UserType {
	int passwordMaxAgeInDays;
	bool allowedToPrintReport;
	UserType(int passwordMaxAgeInDays, bool allowedToPrintReport) {
		this.passwordMaxAgeInDays = passwordMaxAgeInDays;
		this.allowedToPrintReport = allowedToPrintReport;
	} 
	public int getPasswordMaxAgeInDays() {
		return passwordMaxAgeInDays;
	} 
	public bool canPrintReport() {
		return allowedToPrintReport;
	} 
	private const int PASSWORD_AGE_NORMAL = 90;
	static UserType normalUserType = new UserType(
	   PASSWORD_AGE_NORMAL, true);
    private const int PASSWORD_AGE_ADMIN = 30;
	static UserType adminUserType = new UserType(
	   PASSWORD_AGE_ADMIN, true);
	static UserType guestUserType = 
		new UserType(Int32.MaxValue, false);
}
class InventoryApp {
	void login(UserAccount userLoggingIn, string password) {
		if (userLoggingIn.checkPassword(password)) {
			DateTime today = new DateTime();
			DateTime expiryDate= 
				getAccountExpiryDate(userLoggingIn);
            if (DateTime.Compare(today,expiryDate) > 0) {
				//prompt the user to change password
				//...
			}
		}
	}
	DateTime getAccountExpiryDate(UserAccount account) {
		int passwordMaxAgeInDays = getPasswordMaxAgeInDays(account);
		DateTime expiryDate = account.dateOfLastPasswdChange;
		return expiryDate.AddDays(passwordMaxAgeInDays);
	}
	int getPasswordMaxAgeInDays(UserAccount account) {
		return account.getType().getPasswordMaxAgeInDays();
	}
	void printReport(UserAccount currentUser) {
		bool canPrint;
		canPrint = currentUser.getType().canPrintReport();
		if (!canPrint) {
			throw new Exception("You have no right");
		}
		//print the report.
	}
}
