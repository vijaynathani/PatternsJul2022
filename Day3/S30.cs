class Graphics { //..
}
class Point { //..
}
interface Shape {
    void draw(Graphics graphics);
}
class Line : Shape {
    Point startPoint;
    Point endPoint;
    public void draw(Graphics graphics) {
        graphics.drawLine(getStartPoint(), getEndPoint());
    }
}
class Rectangle : Shape {
    Point lowerLeftCorner;
    Point upperRightCorner;
    public void draw(Graphics graphics) {
        graphics.drawLine(...);
        graphics.drawLine(...);
        graphics.drawLine(...);
        graphics.drawLine(...);
    }
}
class Circle : Shape {
    Point center;
    int radius;
    public void draw(Graphics graphics) {
        graphics.drawCircle(getCenter(), getRadius());
    }
}
class CADApp {
    void drawShapes(Graphics graphics, Shape[] shapes) {
        for (int i = 0; i < shapes.Length; i++) {
            shapes[i].draw(graphics);
        }
    }
}
