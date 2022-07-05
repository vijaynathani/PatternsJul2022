using System;
interface Account {
	bool canLogin();
}
class UserAccount : Account {
	DateTime expiredDate;
	public bool canLogin() {
		return isAccountExpired();
	} 
	bool isAccountExpired() {
		DateTime now = DateTime.Now;
		return DateTime.Compare(expiredDate,now) >= 0;
	}
} 
class AdminAccount : Account {
	bool hasLogin;
	public bool canLogin() {
		return !isTryingMultiLogin();
	} 
	bool isTryingMultiLogin() {
		return hasLogin;
	}
} 
class ERPApp {
	public bool checkLoginIssue(Account account) {
		return account.canLogin();
	}
}
