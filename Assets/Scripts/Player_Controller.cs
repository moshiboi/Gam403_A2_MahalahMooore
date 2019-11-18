using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    private int count;
    float moveHorizontal;
    float moveVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //void start updates once at the begging of running the code
    }

    private void Update()
    {
        //moveHorizontal = Input.GetAxis("Horizontal");
        //moveVertical = Input.GetAxis("Vertical");
        //_________________________________________________
        //keyboard inputs are better here
        //void update updates constantely but can be more inconsistent
    }
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 newMovement = Vector3.ClampMagnitude(movement *speed, speed);

        rb.AddForce(newMovement);
        //physics updates are better here
        //fixed update updates at specific moments and is more consistent
    }

}