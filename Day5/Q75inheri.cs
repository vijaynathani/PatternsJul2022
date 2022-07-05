using System;
//Remove the problem in code below.
//Assume that PropertyFileWriter is not used anywhere else
//other than class App.
class FileWriter { 
	//has functions to write to a file
	//..
	public void write(string line) { //...
	}
	public void close() { //...
	}
}
class PropertyFileWriter : FileWriter {
	//...
	public PropertyFileWriter(string file) { //..
	}
    public void writeEntry(string key, string value) {
        base.write(key+"="+value);
    }
	//Many more functions here
}
class App {
    void makePropertyFile() {
        PropertyFileWriter fw = new PropertyFileWriter("f1.properties");
        try {
            fw.writeEntry("conference.abc", "10");
            fw.writeEntry("xyz", "hello");
        } finally {
            fw.close();
        }
    }
}
