using System;
//Improve the code
class UserAccount {
    public const int USERTYPE_NORMAL = 0;
    public const int USERTYPE_ADMIN  = 1;
    public const int USERTYPE_GUEST  = 2;
    int userType;
	public int getType() { return userType; }

    string id;
    string name;
    string password;
    public DateTime dateOfLastPasswdChange;
    public bool checkPassword(string password) {
		bool r = false;
        //...
		return r;
    }
}
class InventoryApp {
    void login(UserAccount userLoggingIn, string password) {
        if (userLoggingIn.checkPassword(password)) {
            DateTime today = new DateTime();
            DateTime expiryDate =
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
        expiryDate.AddDays(passwordMaxAgeInDays);
        return expiryDate;
    }

    int getPasswordMaxAgeInDays(UserAccount account) {
        switch (account.getType()) {
        case UserAccount.USERTYPE_NORMAL:
            return 90; 
        case UserAccount.USERTYPE_ADMIN:
            return 30; 
        case UserAccount.USERTYPE_GUEST:
            return Int32.MaxValue;
		default:
			throw new Exception("error");
        }
    }

    void printReport(UserAccount currentUser) {
        bool canPrint = false;
        switch (currentUser.getType()) {
        case UserAccount.USERTYPE_NORMAL:
            canPrint = true;
            break;
        case UserAccount.USERTYPE_ADMIN:
            canPrint = true;
            break;
        case UserAccount.USERTYPE_GUEST:
            canPrint = false; break;
        }
        if (!canPrint) {
            throw new Exception("You have no right");
        } //print the report.
    }
}
