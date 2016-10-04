using UnityEngine;
using System.Collections;
//Most of this code came from watch https://www.youtube.com/watch?v=U1UkKw12pQo&t=1041s. 
//I chose to use it because of previous attempts of writing a similar code.
public class movingPlatform : MonoBehaviour {


    public Transform platform;//the platform to move
    public Transform fallingAct;//added to allow for the "fallen tile" won't be deleted, remaining visible.
    public Transform startTrans;//start location for platform
    public Transform endTrans;//end location for platform
    public float platformSpeed;//the speed, in Unity Units/Second, of the platform's movement
    
    //arent public because they get set internally.
    Vector3 direction;
    Transform destination;

    void Start()
    {
        SetDestination(startTrans);
    }

    void FixedUpdate()//because of the physics on the rigidbodies(?) being harder to calculate for the comp
    {
        platform.GetComponent<Rigidbody>().MovePosition(platform.position + direction * platformSpeed * Time.fixedDeltaTime);
        fallingAct.transform.position = platform.transform.position;//makes the red fallingAct move with the platform;
        //to figure out which way the platform is moving
        if(Vector3.Distance (platform.position, destination.position) < platformSpeed * Time.fixedDeltaTime)
        {
            if(destination == startTrans)
            {
                SetDestination(endTrans);
            }
            else
            {
                SetDestination(startTrans);
            }
        }

    }

    void SetDestination(Transform dest)//this will set up where the platform will be moving towards.
    {
        destination = dest;
        direction = (destination.position - platform.position).normalized; //normalized to set it either left or right
    }

    
    //------------------------Gizmos------------------------------
    void OnDrawGizmos()
    {
        //Draws a green wire cube where the plaform will move towards the "start"
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(startTrans.position, platform.localScale);
        //Draws a red wire cube where the platform will move towards the "end"
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(endTrans.position, platform.localScale);
    }

}

