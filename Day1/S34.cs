class ResultSet { //..
}
class PreparedStatement { //..
	public void setstring(int number, string value) {//...
	}
	public ResultSet executeQuery() { ResultSet r = null;
		//...
		return r;
	}
	public void executeUpdate() { //...
	}
	public void close() { }
}
class Connection { //..
	public PreparedStatement prepareStatement(string sql) { //..
		return null;
	}
}
class Customer {
	public string name, idNumber;
}

class CustomersInDB {
	Connection conn;
	private string replaceSymbolsInID(string idNumber) {
		string symbolsToReplace = "-()/";
		for (int i = 0; i < symbolsToReplace.Length; i++) {
			idNumber = idNumber.Replace(symbolsToReplace[i], ' ');
		} 
		return idNumber;
	}
	Customer getCustomer(string IDNumber) {
		Customer r = null;
		PreparedStatement st = conn.prepareStatement(
			"select * from customer where ID=?");
		try {
			st.setstring(1, replaceSymbolsInID(IDNumber));
			ResultSet rs = st.executeQuery();
			//...
		} finally {
			st.close();
		}
		return r;
	}
	void addCustomer(Customer customer) {
		PreparedStatement st = conn.prepareStatement(
			"insert into customer values(?,?,?,?)");
		try {
			st.setstring(1, replaceSymbolsInID(customer.idNumber));
			st.setstring(2, customer.name);
			//...
			st.executeUpdate();
			//...
		} finally {
			st.close();
		}
	}
}
