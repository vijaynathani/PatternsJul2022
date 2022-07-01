using System.Collections.Generic;
class Restaurant { //...
}
class Product { //..
}
class OrderDetails {//..
}

// Point out and remove the code smells in the code
class Customer {
    string homeAddress;
    string workAddress;
	public string getHomeAddress() { return homeAddress; }
	public string getWorkAddress() { return workAddress; }
}
class Order {
    string orderId;
    Restaurant restaurantReceivingOrder;
    Customer customerPlacingOrder;

    //"H": deliver to home address of the customer.
    //"W": deliver to work address of the customer.
    //"O": deliver to the address specified here.
    string addressType;

    string otherAddress; //address if addressType is "O".
    Dictionary<Product,OrderDetails> orderItems;

    public string getDeliveryAddress() {
        if (addressType.Equals("H")) {
            return customerPlacingOrder.getHomeAddress();
        } else if (addressType.Equals("W")) {
            return customerPlacingOrder.getWorkAddress();
        } else if (addressType.Equals("O")) {
            return otherAddress;
        } else {
            return null;
        }
    }
}
