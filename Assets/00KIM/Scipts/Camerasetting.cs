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

    public GameObject target_floor1;
    public GameObject target_floor2;
    public GameObject target_floor3;

    public int hall_check_distance = 3;

    void Start()
    {
        transform.position = ca_poistion1.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player_in_hall(floor1)&&player_in_hall(floor2))
        {
            transform.position = ca_poistion3.transform.position;
            transform.LookAt(target_floor1.transform.position);
        }
        else
        {
            if(cal_distance(floor1)<cal_distance(floor2))
            {
                transform.position = ca_poistion1.transform.position;
                transform.LookAt(target_floor3.transform.position);
            }
            else
            {
                transform.position = ca_poistion2.transform.position;
                transform.LookAt(target_floor2.transform.position);
            }
        }

    }

    public bool player_in_hall(GameObject f)
    {

        if (cal_distance(f) < hall_check_distance)
            return true;
        else
            return false;
    }

    public float cal_distance(GameObject f)
    {

        Vector3 cal = f.transform.position - playerposition.transform.position;
        float scarla = Vector3.Magnitude(cal);
        float dis = Mathf.Sqrt(scarla * scarla);
        return dis;


    }


}
