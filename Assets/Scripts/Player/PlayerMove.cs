using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private float y;
    private bool jumpBuff = false;
    public static  Vector3 position; 
    Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        FaceMouse();
        position = transform.position;
    }
    void Move()
    {


        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.AddRelativeForce(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0), ForceMode.Force);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            rb.AddRelativeForce(new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime), ForceMode.Force);

        }

        if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0 &&!jumpBuff)
        {
            rb.AddForce(new Vector3(0, Time.deltaTime * speed/2, 0), ForceMode.Impulse);
            jumpBuff= true;
            StartCoroutine(JumpWait());
        }

    }

    void FaceMouse()
    {
        y = Input.GetAxis("Mouse X");
        rotate = new Vector3(0, y*CameraMove.sensitivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }

    IEnumerator JumpWait()
    {
        yield return new WaitForSeconds(0.5f);
        jumpBuff= false;
    }

}
