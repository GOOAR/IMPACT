using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float movespeed = 3.0f;
    public float turning_speed = 5.0f;

    public float reverse_gravity = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float jum = Input.GetAxis("Jump");


        float turning_X = Input.GetAxis("Mouse X");
        float turning_Y = Input.GetAxis("Mouse Y");


        Vector3 dir = new Vector3(h, 0, v);

        float dis = dir.magnitude;
        dir.Normalize();

        Vector3 uping = new Vector3(0, jum, 0);

        uping.Normalize();


        transform.position += dir * movespeed * Time.deltaTime;
        transform.position += uping * reverse_gravity * Time.deltaTime;



        //transform.Rotate(Vector3.up * -turning_speed * turning_X);
        //transform.Rotate(Vector3.right * turning_speed * turning_Y);
    }
}
