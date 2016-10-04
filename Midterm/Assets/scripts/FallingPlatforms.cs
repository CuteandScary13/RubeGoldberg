using UnityEngine;
using System.Collections;

public class FallingPlatforms : MonoBehaviour {
    public GameObject platform;
    public float destroyTime = 3f;
    
    //float timer;
    void OnTriggerEnter(Collider activator)
    {
        if (activator.gameObject.tag == "Player")
        {
            Destroy(platform, destroyTime);
        }
    }
}
