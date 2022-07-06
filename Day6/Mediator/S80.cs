/* Problems	that existed in the old code
 * - circular references. DIP violated.
 *	 Code not reusable in a different enviroment
 * - SRP violated
 */
using System;
class Frame { //...
}
class StatusBar { //...
	public void setText(string t) {}
}
delegate void ShowMessage(string message);
class ZipMainFrame : Frame {
    StatusBar sb;
    void makeZip() {
        string zipFilePath="...";
        string[] srcFilePaths=null;
        //setup zipFilePath and srcFilePaths according to the UI.
        //...
        ZipEngine ze = new ZipEngine();
        ze.makeZip(zipFilePath, srcFilePaths, setStatusBarText);
    }
    public void setStatusBarText(string statusText) {
        sb.setText(statusText);
    }
}
class ZipEngine {
    public void makeZip(string zipFilePath, 
			string[] srcFilePaths, ShowMessage f) {
        //create zip file at the path.
        //...
        for (int i = 0; i < srcFilePaths.Length; i++) {
            f("Zipping "+srcFilePaths[i]);
            //add the file srcFilePaths[i] into the zip file.
            //...
        }
    }
}
class TextModeApp {
	void makeZip() {
		String zipFilePath="";
		String[] srcFilePaths=null;
		//...
		ZipEngine ze = new ZipEngine();
		ze.makeZip(zipFilePath, srcFilePaths, display);
	}
	void display(string message) {
		Console.WriteLine(message);
	}	
}
