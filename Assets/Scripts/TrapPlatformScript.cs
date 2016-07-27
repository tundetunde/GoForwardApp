using UnityEngine;
using System.Collections;

public class TrapPlatformScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
            transform.localScale += new Vector3(0, 3f, 0);
    }
}
