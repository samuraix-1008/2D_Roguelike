using UnityEngine;
using System.Collections;
using Completed;

public class Player : MovingObject {
	public int wallDamage = 1; 
	public int pointsperFood = 10; 
	public int pointsperSoda = 20; 
	public float restartLevelDelay = 1f; 

	private Animator animator;
	private int food; 

	// Use this for initialization
	protected override void Start () 
	{
		animator = GetComponent<Animator> (); 

		food = GameManager.instance.playerFoodPoints;

		base.Start ();
	}

	private void OnDisable()
	{
		GameManager.instance.playerFoodPoints = food;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


protected override void AttemptMove <T> (int xDir, int yDiy)
{
	food--; 

	base.AttemptMove <T> (xDir, yDir);

	RaycastHit2D hit; 

	CheckIfGameOver();

	GameManager.instance.playersTurn = false; 
}

private void CheckIfGameOver()
{
	if (food <=0)
		GameManager.instance.GameOver();
}
}