import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random appleGenerator;
	private Point appleObject;
	private Color snakeColor;

	public Apple(Snake s) {
		appleObject = createApple(s);
		snakeColor = Color.RED;
	}

	private Point createApple(Snake s) {
		appleGenerator = new Random();
		int x = appleGenerator.nextInt(30) * 20;
		int y = appleGenerator.nextInt(30) * 20;
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.getXCoord() || y == snakePoint.getYCoord()) {
				return createApple(s);
			}
		}
		return new Point(x, y);
	}

	public void drawApple(Graphics g){
		appleObject.drawAnimal(g, snakeColor);
	}

	public Point getPoint(){
		return appleObject;
	}
}
