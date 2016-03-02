import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Point {
	private int xCoord, yCoord;
	private final int width = 20;
	private final int height = 20;

	public Point(Point p){
		this(p.xCoord, p.yCoord);
	}

	public Point(int x, int y){
		this.xCoord = x;
		this.yCoord = y;
	}

	public int getXCoord() {
		return this.xCoord;
	}
	public void setXCoord(int x) {
		this.xCoord = x;
	}
	public int getYCoord() {
		return this.yCoord;
	}
	public void setYCoord(int y) {
		this.yCoord = y;
	}

	public void drawAnimal(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(xCoord, yCoord, width, height);
		g.setColor(color);
		g.fillRect(xCoord + 1, yCoord + 1, width - 2, height - 2);
	}

	public String toString() {
		return "[x=" + xCoord + ",y=" + yCoord + "]";
	}

	public boolean equals(Object currObject) {
        if (currObject instanceof Point) {
            Point currPoint = (Point)currObject;
            return (xCoord == currPoint.xCoord) && (yCoord == currPoint.yCoord);
        }
        return false;
    }
}
