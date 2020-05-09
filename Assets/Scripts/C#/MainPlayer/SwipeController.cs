using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {

	private Touch startTouch;
	private float touchDistance;
	private bool hasSwiped = false;

	private PlayerControls controls;
	// Use this for initialization
	void Start () 
	{
		controls = FindObjectOfType<PlayerControls> ();	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		foreach (Touch t in Input.touches) 
		{
			if (t.phase == TouchPhase.Began) 
			{
				startTouch = t;
				Debug.Log ("touch started");
			} 
			else if (t.phase == TouchPhase.Stationary && !hasSwiped) 
			{
				Debug.Log ("touch swiped");
				float deltaX = startTouch.position.x - t.position.x;
				float deltaY = startTouch.position.y - t.position.y;
				touchDistance = Mathf.Sqrt ((deltaX * deltaX) + (deltaY * deltaY));
				bool swipeOnX = Mathf.Abs (deltaX) > Mathf.Abs (deltaY);

				if (touchDistance > 1f) 
				{
					if (swipeOnX && deltaX > 0) 
					{ //left
						controls.PlayerWalkLeft (1);
						Debug.Log ("left");
					} 
					else if (swipeOnX && deltaX <= 0) 
					{ //right
						Debug.Log ("right");
						controls.PlayerWalkRight (1);
					} 
					else if (!swipeOnX && deltaY > 0) 
					{ //down
						Debug.Log ("down");
						controls.PlayerWalkUp (1);
					} 
					else if (!swipeOnX && deltaY <= 0) 
					{ //up
						Debug.Log ("up");
						controls.PlayerWalkDown (1);
					}
					hasSwiped = true;
				}

			} 
			else if (t.phase == TouchPhase.Ended) 
			{
				Debug.Log ("touch ended");
				startTouch = new Touch ();
				//controls.PlayerWalkDown (0);
				//controls.PlayerWalkLeft (0);
				//controls.PlayerWalkRight (0);
				//controls.PlayerWalkUp (0);
				hasSwiped = false;
			} 
			else 
			{	
				Debug.Log ("else statement");
				startTouch = new Touch ();
				hasSwiped = false;
			}

		}

	}
}

/*public GameObject player;

// Use this for initialization
void Start () {

}

// Update is called once per frame
void Update () {

	if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
	{
		Vector2 touchPosition = Input.GetTouch(0).position;
		double halfScreen = Screen.width / 2.0;

		//Check if it is left or right?
		if(touchPosition.x < 0){
			player.transform.Translate(Vector3.left * 5 * Time.deltaTime);
		} else if (touchPosition.x > 0) {
			player.transform.Translate(Vector3.right * 5 * Time.deltaTime);
		}

	}

}
}*/
