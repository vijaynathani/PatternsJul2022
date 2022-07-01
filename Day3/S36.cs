interface Currency {
	string format(int amount);
} 
class USDCurrency : Currency {
	public string format(int amount) {
		//return something like $1,200
	}
} 
class RMBCurrency : Currency {
	public string format(int amount) {
		//return something like RMB1,200
	}
} 
class ESCUDOCurrency : Currency {
	public string format(int amount) {
		//return something like $1.200
	}
}
