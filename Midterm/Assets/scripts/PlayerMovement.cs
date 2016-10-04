using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    CharacterController cController;
    float jumpTimer;
    public float jumpDist = 5f;

    // Use this for initialization
    void Start()
    {
        cController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");


        cController.SimpleMove(transform.forward * inputY * 5f);
        cController.SimpleMove(transform.right * inputX * 5f);
        transform.Rotate(0f, mouseX * 5f, 0f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cController.Move(transform.up * jumpDist);
           // jumpTimer = Time.time + 1f;
        }
        if (Time.time < jumpTimer)
        {
            cController.Move(transform.up * 0.1f);
        }
    }
}
