class Speaker {
	public const int HIGH_FREQUENCY=10000;
	public void setFrequency(int f) { }
	public void turnOn() { }
}
/* Point out the problem in the code below. Further suppose that 
 * you need to reuse the heat sensor code in another application. 
 * What should you do?
 */
class Cooker {
    HeatSensor heatSensor;
    Speaker speaker;
    public void alarm() {
        speaker.setFrequency(Speaker.HIGH_FREQUENCY);
        speaker.turnOn();
    }
}
class HeatSensor {
    Cooker cooker;
    public HeatSensor(Cooker cooker) {
        this.cooker = cooker;
    }
    public void checkOverHeated() {
        if (isOverHeated()) {
            cooker.alarm();
        }
    } 
    public bool isOverHeated() { //...
		return false;
    }
}
