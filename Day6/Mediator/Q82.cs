/* Point out the problem in the code below. Further suppose that you 
 * need to reuse the fax machine code in another application. What should 
 * you do?
 */
using System;
class FaxMachineHardware {
	public void setStationId(string faxNo){}
	public void setRecipientFaxNo(string faxno){}
	public void start(){}
	public void done(){}
	public Graphics newPage() { return null; }
}
class Graphics { //...
}
class MainApp {
    string faxNo;
    void main() {
        FaxMachine faxMachine = new FaxMachine(this);
        faxMachine.sendFax("783675", "hello");
    }
	public string getFaxNo() { return faxNo; }
}
class FaxMachine {
    MainApp app;
    public FaxMachine(MainApp app) {
        this.app = app;
    }
    public void sendFax(string toFaxNo, string msg) {
        FaxMachineHardware hardware = new FaxMachineHardware();
        hardware.setStationId(app.getFaxNo());
        hardware.setRecipientFaxNo(toFaxNo);
        hardware.start();
		bool morePageIsNeeded = true;
        try {
            do {
                Graphics graphics = hardware.newPage();
                //draw the msg into the graphics.
            } while (morePageIsNeeded);
        } finally {
            hardware.done();
        }
    }
}
