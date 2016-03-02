import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random appleGenerator;
	private Point appleObject;
	private Color snakeColor;

    /**
     *This method creates apple class
     * @param s The snake object
     * @return creates apple class
     */

	public Apple(Snake s) {
		appleObject = createApple(s);
		snakeColor = Color.RED;
	}

	/**
     *This method returns new point for apple food
     * @param s The Snake object
     * @return created apple position or new point
     */

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

	/**
     *This method draws the apple object
     * @param g The graphic object
     * @return draws the apple object
     */

	public void drawApple(Graphics g){
		appleObject.drawAnimal(g, snakeColor);
	}

    /**
     *This method returns the position of apple object
     * @param no parameters
     * @return The position of apple object
     */

	public Point getPoint(){
		return appleObject;
	}
}
