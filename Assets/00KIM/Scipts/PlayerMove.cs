using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Desk;



    public float movespeed = 3.0f;
    public float turning_speed = 3.0f;

    public float reverse_gravity = 5.0f;

    public float xRotate = 0.0f;

    public Camera cam; //메인카메라

    


    /// <summary>
    /// lesson code
    /// </summary>
    public float rotSpeed = 10.0f;

    public bool rotateX = false;
    public bool rotateY = false;

    float rotX = 0;
    float rotY = 0;


    /// <summary>
    /// Ray funtion code
    /// </summary>

    Ray ray;
    RaycastHit hitinfo;
    public GameObject player_ray;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float jum = Input.GetAxis("Jump");

        MoveLookAt();

        Vector3 dir = new Vector3(h, 0, v);

        float dis = dir.magnitude;
        dir.Normalize();
        dir = cam.transform.TransformDirection(dir);

        Vector3 uping = new Vector3(0, jum, 0);

        uping.Normalize();

        transform.localPosition += dir * movespeed * Time.deltaTime;
        transform.localPosition += uping * reverse_gravity * Time.deltaTime;

        Player_Camera_move();
        

        //Ray 함수 구현


        if(Input.GetButton("Fire1"))
        {
            ray = new Ray(player_ray.transform.position, cam.transform.forward);


            if(Physics.Raycast(ray, out hitinfo))
            {
                print(hitinfo.transform.name);
                if (hitinfo.transform.name.Contains("Neo_Floor"))
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        GameObject make_it = Instantiate(Desk);
                        make_it.transform.position = hitinfo.point;
                    }
                }
               
            }
           
            ////if(Input.GetKeyDown(KeyCode.D))
            ////{
            ////    GameObject make_it = Instantiate(Desk);                
            ////}
        }
    }
    public void mousemove_check_fuction()
    {
        float mx = Input.GetAxis("Mouse X"); //게임창에서 마우스를 왼쪽 오른쪽으로 이동할때 마다 (왼 -음수 : 오른 +양수)
        float my = Input.GetAxis("Mouse Y"); //게임창에서 마우스를 왼쪽 오른쪽으로 이동할때 마다 (아래 -음수 : 위 +양수)

        rotX += rotSpeed * my * Time.deltaTime;
        rotY += rotSpeed * mx * Time.deltaTime;

        //rx 회전 각을 제한 (화면 밖으로 마우스가 나갔을때 x축 회전 덤블링 하듯 계속 도는 것을 방지)
        rotX = Mathf.Clamp(rotX, -80, 80);
        //x을 돌리는 이유 x축이 이동이 아니라 x축을 회전 해서 위아래 보는 방향은 x축이여야 한다.

        //2. 회전을 한다.
        transform.eulerAngles = new Vector3(-rotX, rotY, 0);


    
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
    void MoveLookAt()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turning_speed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;
        //메인카메라가 바라보는 방향입니다.

        //Vector3 dir = cam.transform.localRotation * Vector3.forward;
        ////카메라가 바라보는 방향으로 팩맨도 바라보게 합니다.
        //transform.localRotation = cam.transform.localRotation;
        ////팩맨의 Rotation.x값을 freeze해놓았지만 움직여서 따로 Rotation값을 0으로 세팅해주었습니다.
        //transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        ////바라보는 시점 방향으로 이동합니다.
        //gameObject.transform.Translate(dir * 0.1f * Time.deltaTime);

        transform.eulerAngles = new Vector3(0, yRotate, 0);

    }

    void Player_Camera_move()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turning_speed;
        float yRotate = transform.eulerAngles.y + yRotateSize;


        float xRotateSize = Input.GetAxis("Mouse Y") * turning_speed;
        float xRotate = transform.eulerAngles.x + xRotateSize;


        xRotate = Mathf.Clamp(xRotate, -60.0f, 60.0f);
        

       



        cam.transform.eulerAngles = new Vector3(-xRotate, yRotate, 0);

    }

}
