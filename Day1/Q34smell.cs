class ResultSet { //..
}
class PreparedStatement { //..
	public void setString(int number, string value) {//...
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
//Improve the code
class CustomersInDB {
    Connection conn;
    public Customer getCustomer(string IDNumber) {
		Customer r =null;
        PreparedStatement st = conn.prepareStatement(
            "select * from customer where ID=?");
        try {
            st.setString(1, IDNumber.Replace('-', ' ').Replace('(', ' ').
                Replace(')', ' ').Replace('/', ' '));
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
            st.setString(1,customer.idNumber.Replace('-', ' ').
                Replace('(', ' ').Replace(')', ' ').Replace('/', ' '));
            st.setString(2, customer.name);
            //...
            st.executeUpdate();
            //...
        } finally {
            st.close();
        }
    }
}
