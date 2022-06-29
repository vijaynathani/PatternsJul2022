using System;
class ActionEvent { //..
}
delegate void ActionPerformed(ActionEvent e);
class JButton { //...
	public void addActionListener(ActionPerformed a) { //..
	}
}
class Dialog { //...
	public void pack() { //...
	}
	public void setLocation (int x, int y) { //..
	}
	public void setVisible(bool v) { //...
	}
}
class JDialog { //..
}
class UIDialogCustomerDeleteOrder : Dialog { //...
	public UIDialogCustomerDeleteOrder(JDialog d, string title, bool v) {
		//..
	}
}
class UIChangeAccountPW: Dialog {
	public UIChangeAccountPW(JDialog d, string title, bool v) {
		//..
	}

}
//Improve the code
class UIDialogCustomerMain : JDialog {
    JButton btnOrderDel;
    JButton btnCustChangePassword;
	void show1(ActionEvent e) {
		Dialog d = new UIDialogCustomerDeleteOrder(
			this, "Del Order", true);
		d.pack();
		d.setLocation(400,200);
		d.setVisible(true);
	}
	void show2(ActionEvent e) {
		Dialog d = new UIChangeAccountPW(
				this, "chg pw", true);
		d.pack();
		d.setLocation(400,200);
		d.setVisible(true);
	}
    void bindEvents() {
        //...
        btnOrderDel.addActionListener(show1);
        btnCustChangePassword.addActionListener(show2);
    }
    //...
}

class UIDialogRestaurantMain : JDialog {
    JButton btnChangePassword;
	void show3(ActionEvent e) {
		Dialog d = new UIChangeAccountPW(
			this, "chg pw", true);
		d.pack();
		d.setLocation(400,200);
		d.setVisible(true);
	}
    void bindEvents() {
        //...
        btnChangePassword.addActionListener(show3);
    }
    //...
}
