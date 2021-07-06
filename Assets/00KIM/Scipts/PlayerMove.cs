using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float movespeed = 3.0f;
    public float turning_speed = 3.0f;

    public float reverse_gravity = 5.0f;

    public float xRotate = 0.0f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float jum = Input.GetAxis("Jump");


        //float turning_X = Input.GetAxis("Mouse X");
        //float turning_Y = Input.GetAxis("Mouse Y");



        Vector3 dir = new Vector3(h, 0, v);

        float dis = dir.magnitude;
        dir.Normalize();

        Vector3 uping = new Vector3(0, jum, 0);

        uping.Normalize();

        transform.localPosition += dir * movespeed * Time.deltaTime;
        transform.localPosition += uping * reverse_gravity * Time.deltaTime;
        
        MouseMoveFuction();

        //transform.position += dir * movespeed * Time.deltaTime;
        //transform.position += uping * reverse_gravity * Time.deltaTime;


    }

    public void MouseMoveFuction()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * turning_speed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turning_speed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        //xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        transform.eulerAngles = new Vector3(0, yRotate, 0);

    }

}
