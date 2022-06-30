using System;
using System.Collections.Generic;
// At the moment the code of a system is shown below:
class Customer {
    string id;
    string name;
    string address;
}
class Supplier {
    string id;
    string name;
    string telNo;
    string address;
}
class SalesSystem {
    List<Customer> customers;
    List<Supplier> suppliers;
}
/* Implement the following new requirements while keeping the code fit:

1. Customers can place orders. Each order has a unique ID. It records the
date of the order, the ID of the customer and the name and quantity of
each item being ordered.
2. The system can list all the orders placed by a particular customer.
3. The system can list all the orders placed for a particular supplier.
4. A supplier can provide a certain discount to some of the customers it
selects (valid for some selected items only). The discount for different
customers or different items may be different. */
