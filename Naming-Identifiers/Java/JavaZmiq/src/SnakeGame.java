import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

@SuppressWarnings("serial")
public class SnakeGame extends Canvas implements Runnable {
	public static Snake mySnake;
	public static Apple apple;
	static int points;

	private Graphics globalGraphics;
	private Thread runThread;
	public static final int width = 600;
	public static final int height = 600;
	private final Dimension gameFieldSize = new Dimension(width, height);

	static boolean gameRunning = false;

	public void paint(Graphics g){
		this.setPreferredSize(gameFieldSize);
		globalGraphics = g.create();
		points = 0;

		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}

	public void run(){
		while(gameRunning){
			mySnake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: write an appropriate exception
			}
		}
	}

	public SnakeGame(){
		mySnake = new Snake();
		apple = new Apple(mySnake);
	}

	public void render(Graphics g){
		g.clearRect(0, 0, width, height+25);

		g.drawRect(0, 0, width, height);
		mySnake.drawSnake(g);
		apple.drawApple(g);
		g.drawString("score= " + points, 10, height + 25);
	}
}

