using System;
public class Font { //..
}
public class ActionListener { //..
}
public class Graphics { //..
}
public class Bitmap { //..
}
public abstract class Button {
	//...
	public void addActionListener(ActionListener listener) {
		//...
	} 
	abstract public void paint(Graphics graphics);
} 
public class LabelButton : Button {
	private Font labelFont;
	private String labelText;
	override public void paint(Graphics graphics) {
		//draw the label text on the graphics using the label's font.
	}
}
public class BitmapButton : Button {
	private Bitmap bitmap;
	override public void paint(Graphics graphics) {
		//draw the bitmap on the graphics.
	}
}
