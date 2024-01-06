using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float x;
    public static float sensitivity=-1f;
    public GameObject player;
    public static Vector3 front;
    Vector3 rotate;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FaceMouse();
        front = new Vector3();
    }

    void FaceMouse() {
        
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(x*-1*sensitivity,0,0);
        transform.eulerAngles = transform.eulerAngles- rotate;
    }
}
