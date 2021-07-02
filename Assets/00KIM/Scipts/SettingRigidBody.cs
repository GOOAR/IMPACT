using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingRigidBody : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cats;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "cat")
        {

        }
    }



}
