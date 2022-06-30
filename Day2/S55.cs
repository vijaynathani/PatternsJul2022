using System;
class JDialog {
}
class JComboBox {
	public void addItem(Report s) { //..
	}
	public Report getSelectedItem() { //
		return null;
	}
}

interface Report {
    void print();
}
class Report1 : Report {
    public string tostring() {
        return "r1";
    }
    public void print() {
        //print some fancy report...
    }
}
class Report2 : Report {
    public string tostring() {
        return "r2";
    }
    public void print() {
        //print another totally different fancy report...
    }
}
//...
class Report31c : Report {
    public string tostring() {
        return "r31c";
    }
    public void print() {
        //print yet another totally different fancy report...
    }
}
class Form1 : JDialog {
    JComboBox comboBoxReportType;
    Report[] reports = { new Report1(), new Report2() //,... 
		,new Report31c() };
    public Form1() {
        comboBoxReportType = new JComboBox();
        for (int i = 0; i < reports.Length; i++) {
            comboBoxReportType.addItem(reports[i]);
        }
    }
    public void onPrintClick() {
        Report report = comboBoxReportType.getSelectedItem();
        report.print();
    }
}
