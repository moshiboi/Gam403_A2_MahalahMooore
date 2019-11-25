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

    public GameObject Pickup, Pickup1, Pickup2, Pickup3, Pickup4;
        public GameObject Plane, Plane1, Plane2, Plane3, Plane4;
    public GameObject Menu;

    bool paused;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //void start updates once at the begging of running the code
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                Time.timeScale = 0;
                paused = false;
                        Menu.SetActive(true);
            }

            else if (paused == false)
            {
                Time.timeScale = 1;
                paused = true;
                Menu.SetActive(false);
            }
            
        }

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
        Vector3 newMovement = Vector3.ClampMagnitude(movement * speed, speed);

        rb.AddForce(newMovement);
        //physics updates are better here
        //fixed update updates at specific moments and is more consistent
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            if (other.gameObject == Pickup)
            {
                StartCoroutine(Timer(Plane, 5));
            }

            if (other.gameObject == Pickup1)
            {
                StartCoroutine(Timer(Plane1, 5));
            }

            if (other.gameObject == Pickup2)
            {
                StartCoroutine(Timer(Plane2, 5));
            }

            if (other.gameObject == Pickup3)
            {
                StartCoroutine(Timer(Plane3, 5));
            }

            if (other.gameObject == Pickup4)
            {
                StartCoroutine(Timer(Plane4, 5));
            }


            other.gameObject.SetActive(false);
            print("Pickup");
        }
    }

    IEnumerator Timer (GameObject Obj,float time)
    {
        Obj.SetActive(true);
        yield return new WaitForSeconds(time);
        Obj.SetActive(false);
    }
}