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

enum DeliveryAddress {
    HOME_ADDRESS, WORK_ADDRESS, OTHER_ADDRESS
}
class Order {
    string orderId;
    Restaurant restToReceiveOrder;
    Customer customerPlacingOrder;

    string shippingAddress;
    Dictionary<string,OrderItem> orderItems;

    public double getTotalAmount() {
        Decimal totalAmt= Decimal.Zero;
		foreach(OrderItem nextOrderItem in orderItems.Values) { 
            totalAmt += new Decimal(nextOrderItem.getAmount());
        }
        return Decimal.ToDouble(totalAmt);
    }
}
