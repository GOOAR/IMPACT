using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerasetting : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerposition;
    public GameObject ca_poistion1;
    public GameObject ca_poistion2;
    public GameObject ca_poistion3;

    public GameObject floor1;
    public GameObject floor2;




    void Start()
    {
        transform.position = ca_poistion1.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }
}
