import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake{

	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;

	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Point(300, 100));
		snakeBody.add(new Point(280, 100));
		snakeBody.add(new Point(260, 100));
		snakeBody.add(new Point(240, 100));
		snakeBody.add(new Point(220, 100));
		snakeBody.add(new Point(200, 100));
        snakeBody.add(new Point(180, 100));
		snakeBody.add(new Point(160, 100));
		snakeBody.add(new Point(140, 100));
		snakeBody.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}

	public void drawSnake(Graphics g) {
		for (Point point : this.snakeBody) {
			point.DrawAnimal(g, snakeColor);
		}
	}

	public void tick() {
		Point newPosition = new Point((snakeBody.get(0).getXCoord() + velocityX), (snakeBody.get(0).getYCoord() + velocityY));

		if (newPosition.getXCoord() > SnakeGame.width - 20) {
		 	SnakeGame.gameRunning = false;
		} else if (newPosition.getXCoord() < 0) {
			SnakeGame.gameRunning = false;
		} else if (newPosition.getYCoord() < 0) {
			SnakeGame.gameRunning = false;
		} else if (newPosition.getYCoord() > SnakeGame.height - 20) {
			SnakeGame.gameRunning = false;
		} else if (SnakeGame.apple.getPoint().equals(newPosition)) {
			snakeBody.add(SnakeGame.apple.getPoint());
			SnakeGame.apple = new Apple(this);
			SnakeGame.points += 50;
		} else if (snakeBody.contains(newPosition)) {
			SnakeGame.gameRunning = false;
			System.out.println("You ate yourself");
		}

		for (int i = snakeBody.size()-1; i > 0; i--) {
            snakeBody.set(i, new Point(snakeBody.get(i-1)));
		}
		snakeBody.set(0, newPosition);
	}

	public int getVelX() {
		return velocityX;
	}

	public void setVelX(int velX) {
		this.velocityX = velX;
	}

	public int getVelY() {
		return velocityY;
	}

	public void setVelY(int velY) {
		this.velocityY = velY;
	}
}
