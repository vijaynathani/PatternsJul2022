//Improve the code
using System;
class Account {
    public const int LEVEL_USER = 1;
    public const int LEVEL_ADMIN = 2;
    int accountLevel;

    DateTime expiredDate; // for user account only

    public bool hasLogin; // for admin account only
	public int getLevel() { //..
		return 0;
	}
	public DateTime getExpiredDate() { 
		return expiredDate;
	}
}
class ERPApp {
    public bool checkLoginIssue(Account account) {
        if (account.getLevel() == Account.LEVEL_USER) {
            // Check the account expired date
            DateTime now = DateTime.Now;
            return DateTime.Compare(account.getExpiredDate(),now) >= 0;
        } else if (account.getLevel() == Account.LEVEL_ADMIN) {
            // No expired date for admin account
            // Check multilogin
            if (account.hasLogin)
                return false;
            return true;
        }
        return false;
    }
}
