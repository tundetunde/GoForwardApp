using UnityEngine;
using System.Collections;

public class SpawnPickUps : MonoBehaviour {
    GameObject _lastPlatform;

    public static GameObject SpawnPlatform(GameObject gameObject, float x, float y, float z)
    {
        // Generating random number between 0 and 1. That will decide that the new platform should create either on left or right
        GameObject _lastPlatform;
        _lastPlatform = Instantiate(gameObject, new Vector3(x, y + 0.5f, z),
                    Quaternion.identity) as GameObject;
        return _lastPlatform;
    }

}
