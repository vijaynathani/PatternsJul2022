class JDialog {
}
class JComboBox {
	public void addItem(string s) { //..
	}
	public string getSelectedItem() { //
		return null;
	}
}
//Improve the code
class Form1 : JDialog {
    JComboBox comboBoxReportType;
    public Form1() {
        comboBoxReportType = new JComboBox();
        comboBoxReportType.addItem("r1");
        comboBoxReportType.addItem("r2");
        //...
        comboBoxReportType.addItem("r31c");
    }
    void processReport1() {
        //print some fancy report...
    }
    void processReport2() {
        //print another totally different fancy report...
    }
    //...
    void processReport31c() {
        //print yet another totally different fancy report...
    }
    void printReport(string repNo) {
        if (repNo.Equals("r1"))
            processReport1();
        else if (repNo.Equals("r2"))
            processReport2();
            //...
        else if (repNo.Equals("r31c"))
            processReport31c();
    }
    public void onPrintClick() {
        printReport(comboBoxReportType.getSelectedItem());
    }
}
