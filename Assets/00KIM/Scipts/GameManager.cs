using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public GameObject canvasUI;

    public int kim_mode_UI;


    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        kim_mode_UI = 1;
    }

    void Update()
    {
        
    }


    public void mode_button1()
    {
        kim_mode_UI = 1;
    }

    public void mode_button2()
    {
        kim_mode_UI = 2;
    }
    public void mode_button3()
    {
        kim_mode_UI = 3;
    }

}
