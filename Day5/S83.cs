class Speaker {
	public const int HIGH_FREQUENCY=10000;
	public void setFrequency(int f) { }
	public void turnOn() { }
}

delegate void AlarmTurnOn();

class Cooker {
    HeatSensor heatSensor;
    Speaker speaker;
	void alarmStart() {
		speaker.setFrequency(Speaker.HIGH_FREQUENCY);
		speaker.turnOn();
	}
    public AlarmTurnOn getAlarm() { return alarmStart; }
}
class HeatSensor {
    AlarmTurnOn alarm;
    public HeatSensor(AlarmTurnOn alarm) {
        this.alarm = alarm;
    }
    public void checkOverHeated() {
        if (isOverHeated()) {
            alarm();
        }
    }
    public bool isOverHeated() { //...
		return false;
    }
    //...
}
