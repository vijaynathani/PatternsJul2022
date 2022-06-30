using System;
using System.Collections.Generic;
class Restaurant { //...
}
class Customer { //..
}
class OrderItem { //..
	public double getAmount() { //..
		return 0;
	}
}
//Improve the code
class Order {
    string orderId; //order ID.
    Restaurant r1; //the order is placed for this restaurant.
    Customer c1; //the order is created by this customer.
    string address; //Shipping address

    Dictionary<string,OrderItem> orderItems; //order items.

    //get the total amount of this order.
    public double getTotalAmt() {
        //total amount.
        Decimal amt= Decimal.Zero;
        //for each order item do...
		foreach (OrderItem oi in orderItems.Values) { 
            //add the amount of the next order item.
            amt = Decimal.Add(amt, 
					new Decimal(oi.getAmount()));
        }
        return Decimal.ToDouble(amt);
    }
}
