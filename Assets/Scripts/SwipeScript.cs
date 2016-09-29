using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwipeScript : MonoBehaviour {
    public static float speed = 3;
    Rigidbody rb;
    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;
    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;
    float ButtonCooler = 0.5f ; // Half a second before reset
    float ButtonCount = 0;
	public static int speedUpVal = 0;


    // Update is called once per frame
    void Update()
    {

        //Tap Screen to move forward
        if (Input.GetMouseButtonDown(0))
        {
            if (ButtonCooler > 0 && ButtonCount == 1/*Number of Taps you want Minus One*/)
            {
                //DOUBLE TAP TO JUMP
                //rb.velocity = new Vector3(0, speed, speed);
            }
            else
            {
                rb.velocity = new Vector3(0, 0, speed);
                ButtonCooler = 0.5f;
                ButtonCount += 1;
            }

            
        }

        if (ButtonCooler > 0)
            ButtonCooler -= 1 * Time.deltaTime;
        else
            ButtonCount = 0;

        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        isSwipe = true;
                        fingerStartTime = Time.time;
                        fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        isSwipe = false;
                        rb.velocity = new Vector3(0, 0, speed);
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                 
                                    rb.velocity = new Vector3(speed, 0, 0);
                
                                        
                                }
                                else
                                {
                                    // MOVE LEFT
                                    rb.velocity = new Vector3(-speed, 0, 0);
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    // MOVE UP
                                    rb.velocity = new Vector3(0, 0, speed);
                                }
                                else
                                {
                                    // MOVE DOWN
                                }
                            }

                        }
                        break;
                }
            }
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	public static void IncreaseSpeed()
	{
		switch (speedUpVal) {
		case 0:
			speed = 5.0f;
			break;
		case 1:
			speed = 5.5f;
			break;
		case 2:
			speed = 6.0f;
			break;
		case 3:
			speed = 6.5f;
			break;
		case 4:
			speed = 7.0f;
			break;
		case 5:
			speed = 7.5f;
			break;
		case 6:
			speed = 8.0f;
			break;
		}
	}

	public static void DecreaseSpeed()
	{
		switch (speedUpVal) {
		case 0:
			speed = 1.5f;
			break;
		case 1:
			speed = 2.0f;
			break;
		case 2:
			speed = 2.5f;
			break;
		case 3:
			speed = 3.0f;
			break;
		case 4:
			speed = 3.5f;
			break;
		case 5:
			speed = 4.0f;
			break;
		case 6:
			speed = 4.5f;
			break;
		}
	}
}
