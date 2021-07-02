using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float cat_movespeed;
    public float axis_x;
    public float axis_y;
    public float axis_z;
    public Vector3 move;

    public float save_time;


    void Start()
    {
        cat_movespeed = 0.5f;
        axis_x = Random.value;
        axis_y = 0;
        axis_z = Random.value;
        move = new Vector3(axis_x, axis_y, axis_z);
        move.Normalize();
        save_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (save_time > 5)
        {
            axis_x = Random.value;
            axis_y = 0;
            axis_z = Random.value;
            move = new Vector3(axis_x, axis_y, axis_z);
            move.Normalize();
            save_time = 0.0f;
        }
        else
        {
            save_time += Time.deltaTime;
        }



        transform.position += move * cat_movespeed * Time.deltaTime;


    }

    private void OnCollisionEnter(Collision collision)
    {

        int new_raotaion = Random.Range(0, 91);
        transform.rotation = new Quaternion(0, new_raotaion, 0, 1);
        axis_x *= -1;
        axis_y *= -1;
        axis_z *= -1;
        move = new Vector3(axis_x, axis_y, axis_z);
        move.Normalize();

    }


}
