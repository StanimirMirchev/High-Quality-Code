import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class KeyRecognizer implements KeyListener{

	public KeyRecognizer(SnakeGame game){
		game.addKeyListener(this);
	}

	public void keyPressed(KeyEvent e) {
		int pressedKeyCode = e.getKeyCode();

		if (pressedKeyCode == KeyEvent.VK_W || pressedKeyCode == KeyEvent.VK_UP) {
			if(SnakeGame.mySnake.getVelY() != 20){
				SnakeGame.mySnake.setVelX(0);
				SnakeGame.mySnake.setVelY(-20);
			}
		}
		if (pressedKeyCode == KeyEvent.VK_S || pressedKeyCode == KeyEvent.VK_DOWN) {
			if(SnakeGame.mySnake.getVelY() != -20){
				SnakeGame.mySnake.setVelX(0);
				SnakeGame.mySnake.setVelY(20);
			}
		}
		if (pressedKeyCode == KeyEvent.VK_D || pressedKeyCode == KeyEvent.VK_RIGHT) {
			if(SnakeGame.mySnake.getVelX() != -20){
			SnakeGame.mySnake.setVelX(20);
			SnakeGame.mySnake.setVelY(0);
			}
		}
		if (pressedKeyCode == KeyEvent.VK_A || pressedKeyCode == KeyEvent.VK_LEFT) {
			if(SnakeGame.mySnake.getVelX() != 20){
				SnakeGame.mySnake.setVelX(-20);
				SnakeGame.mySnake.setVelY(0);
			}
		}
		//Other controls
		if (pressedKeyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}

	public void keyReleased(KeyEvent e) {
	}

	public void keyTyped(KeyEvent e) {

	}

}
