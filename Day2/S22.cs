using System;
class Account {
	//...
	bool isComplexPassword(String password){
		return containsLetter(password) &&
			(containsDigit(password) || containsSymbol(password));
	} 
	bool containsLetter(String password) {
		//...
	} 
	bool containsDigit(String password) {
		//...
	} 
	bool containsSymbol(String password) {
		//...	
	}
}
