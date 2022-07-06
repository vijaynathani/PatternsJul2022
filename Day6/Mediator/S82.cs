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
        FaxMachine faxMachine = new FaxMachine(faxNo);
        faxMachine.sendFax("783675", "hello");
    }
}
class FaxMachine {
    string stationId;
    public FaxMachine(string stationId) {
        this.stationId = stationId;
    }
    public void sendFax(string toFaxNo, string msg) {
        FaxMachineHardware hardware = new FaxMachineHardware();
        hardware.setStationId(stationId);
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
