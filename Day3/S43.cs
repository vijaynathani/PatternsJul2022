using System.Collections.Generic;
class Restaurant { //...
}
class Product { //..
}
class OrderDetails {//..
}
class Customer {
    string homeAddress;
    string workAddress;
	public string getHomeAddress() { return homeAddress; }
	public string getWorkAddress() { return workAddress; }
}
interface DeliveryAddress {
	string toString();
}
class HomeAddress : DeliveryAddress {
    Customer customer;
    HomeAddress(Customer customer) {
        //...
    }
    public string toString() {
        return customer.getHomeAddress();
    }
}
class WorkAddress : DeliveryAddress {
    Customer customer;
    WorkAddress(Customer customer) {
    	//...
    }
    public string toString() {
        return customer.getWorkAddress();
    }
}
class SpecifiedAddress : DeliveryAddress {
    string addressSpecified;
    SpecifiedAddress(string addressSpecified) {
    	//...
    }
    public string toString() {
        return addressSpecified;
    }
}
class Order {
    string orderId;
    Restaurant restaurantReceivingOrder;
    Customer customerPlacingOrder;
    DeliveryAddress deliveryAddress;
    Dictionary<Product,OrderDetails> orderItems;
    public string getDeliveryAddress() {
        return deliveryAddress.toString();
    }
}
