using System;
//remove the problem in code below
public class Font { //..
}
public class ActionListener { //..
}
public class Graphics { //..
}
public class Bitmap { //..
}
public class Button {
    private Font labelFont;
    private string labelText;
    //...
    public void addActionListener(ActionListener listener) {
        //...
    } 
    public void paint(Graphics graphics) {
        //draw the label text on the graphics using the label's font.
    }
}
public class BitmapButton : Button {
    private Bitmap bitmap;
    public void paint(Graphics graphics) {
        //draw the bitmap on the graphics.
    }
}
