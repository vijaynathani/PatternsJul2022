using System;
//As there is no code that needs to use a PropertyFileWriter as a FileWriter, 
//we should use delegation instead of inheritance:
class FileWriter { 
	//has functions to write to a file
	//..
	public void write(string line) { //...
	}
	public void close() { //...
	}
}
class PropertyFileWriter {
	FileWriter fileWriter;
	public PropertyFileWriter(string file) {//..
	}
	public void writeEntry(String key, String value) {
		fileWriter.write(key+"="+value);
	} 
	public void close() {
		fileWriter.close();
	}
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
