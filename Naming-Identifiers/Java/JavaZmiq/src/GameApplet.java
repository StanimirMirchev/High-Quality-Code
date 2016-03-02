import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private SnakeGame game;
	KeyRecognizer whatIsPressed;

	public void init(){
		game = new SnakeGame();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		whatIsPressed = new KeyRecognizer(game);
	}

	public void paint(Graphics g){
		this.setSize(new Dimension(800, 650));
	}

}
