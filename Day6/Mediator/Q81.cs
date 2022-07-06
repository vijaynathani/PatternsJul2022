/* Point out the problem in the code below. Further suppose that you
 * need to reuse the file copier in a text mode file copying application
 * that will display the progress in its text console as an integer.
 * What should you do?
 */
using System;
class JFrame { //...
}
class ProgressBar {//...
	public void setPercentage(double p){}
}
class File { //..
	public File(string name) {}
	public long length() { return 0;}
}
class MainApp : JFrame {
    ProgressBar progressBar = new ProgressBar();
    public void main() {
        FileCopier fileCopier = new FileCopier(this);
        fileCopier.copyFile(new File("f1.doc"), new File("f2.doc"));
    }
    public void updateProgressBar(int noBytesCopied, int sizeOfSource) {
        progressBar.setPercentage(noBytesCopied*100/sizeOfSource);
    }
}
class FileCopier {
    MainApp app;
    public FileCopier(MainApp app) {
        this.app = app;
    }
    public void copyFile(File source, File target) {
        int sizeOfSource = (int)source.length();
        for (int i = 0; i < sizeOfSource; ) {
			int n=0;
            //read n (<= 512) bytes from source.
            //write n bytes to target.
            i += n;
            app.updateProgressBar(i, sizeOfSource);
        }
    }
}
