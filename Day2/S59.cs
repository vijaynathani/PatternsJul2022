using System;
using System.Collections.Generic;
class Customer { //... No change
}
class Supplier { //.. No change
}
class Order {
    string orderId;
    string customerId;
    string supplierId;
    DateTime orderDate;
    OrderLine[] orderLines;
}
class OrderLine {
    string productName;
    int quantity;
}
class Orders {
    Order[] orders;
    void placeOrder (string customerId, string supplierId //...
			) {
        //...
    }
    void printOrdersByCustomer(string customerId) {
        //...
    }
    void printOrdersForSupplier(string supplierId) {
        //...
    }
}
class Discount {
    string supplierId;
    string customerId;
    string productName;
    double discountRate;
}
class Discounts {
    Discount[] discounts;
    void addDiscount(string supplierId, string customerId,
        string productName,    double discountRate) {
        //...
    }
    double findDiscount(string supplierId,string customerId,
        string productName){
        //...
		return 0;
    }
}
class SalesSystem {
    List<Customer> customers;
    List<Supplier> suppliers;
    Orders orders;
    Discounts discounts;
}
