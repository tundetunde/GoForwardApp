using UnityEngine;
using System.Collections;

public class CameraFollow2 : MonoBehaviour {

    public GameObject ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, 3, ball.transform.position.z +2);

        // Always look at the target
        transform.LookAt(ball.transform);
    }
}
