using System;
using System.Threading;
class PowerSupply {
	public void turnOff() { }
}
class Heater { 
	public void setTemperature(int t) {}
}
class Alarm {
	public void turnOn() {}
}
class HeatSensor {
    PowerSupply powerSupply;
    Alarm alarm; 
	public void checkOverHeated() {
		if (isOverHeated()) {
			powerSupply.turnOff();
			alarm.turnOn();
		}
	}
	private bool isOverHeated() {
		//...
		return false;
	}
	public HeatSensor(Scheduler s) {
		s.add(checkOverHeated);
	}
}
class MoistureSensor {
    Heater heater;
	public void checkRiceCooked() {
		if (getMoisture()<60) {
			heater.setTemperature(50);
		}
	}
	public int getMoisture() {
		//...
		return 0;
	}
	public MoistureSensor(Scheduler s) {
		s.add(checkRiceCooked);
	}
}
class Scheduler {
	static event ThreadStart e1;
    public void run() {
        for (;;) {
            Thread.Sleep(1000);
			e1();
        }
    }
	public void add(ThreadStart t) {
		e1 += t;
	}
	public static void Main(String[] x) {
		Scheduler s1 = new Scheduler();
		new HeatSensor(s1);
		new MoistureSensor(s1);
		Thread t1 = new Thread(s1.run);
		t1.Start();
	}
}
