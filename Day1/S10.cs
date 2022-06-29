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

class UIDialogShower {
    public static void show(Dialog d, int left, int top) {
        d.pack();
        d.setLocation(left, top);
        d.setVisible(true);
    }
    const int LEFT_PIXEL=400, TOP_PIXEL=200;
    public static void showAtDefaultPosition(Dialog d) {
        show(d, LEFT_PIXEL, TOP_PIXEL);
    }
} 
class ChangePasswordButton : JButton {
	readonly JDialog enclosingDialog;
	void show1(ActionEvent e) {
		Dialog d = new UIChangeAccountPW(
			enclosingDialog, "chg pw", true);
		UIDialogShower.showAtDefaultPosition(d);
	}
    public ChangePasswordButton(JDialog enclosingDialog) {
        addActionListener(show1);
    }
}
class UIDialogCustomerMain : JDialog {
    JButton btnOrderDel;
    ChangePasswordButton btnCustChangePassword;
	public UIDialogCustomerMain() {
		btnCustChangePassword = new ChangePasswordButton(this);
	}
	void show1(ActionEvent e) {
		Dialog d = new UIDialogCustomerDeleteOrder
			(this, "Del Order", true);
		UIDialogShower.showAtDefaultPosition(d);
	}
    void bindEvents() {
        //...
        btnOrderDel.addActionListener(show1);
    }
    //...
}
class UIDialogRestaurantMain : JDialog {
    ChangePasswordButton btnChangePassword;
	public UIDialogRestaurantMain() {
    	btnChangePassword = new ChangePasswordButton(this);
	}
    void bindEvents() {
        //...
    }
    //...
}
