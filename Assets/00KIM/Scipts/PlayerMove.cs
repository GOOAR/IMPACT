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

    public Camera cam; //����ī�޶�

    


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
        

        //Ray �Լ� ����


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
        float mx = Input.GetAxis("Mouse X"); //����â���� ���콺�� ���� ���������� �̵��Ҷ� ���� (�� -���� : ���� +���)
        float my = Input.GetAxis("Mouse Y"); //����â���� ���콺�� ���� ���������� �̵��Ҷ� ���� (�Ʒ� -���� : �� +���)

        rotX += rotSpeed * my * Time.deltaTime;
        rotY += rotSpeed * mx * Time.deltaTime;

        //rx ȸ�� ���� ���� (ȭ�� ������ ���콺�� �������� x�� ȸ�� ���� �ϵ� ��� ���� ���� ����)
        rotX = Mathf.Clamp(rotX, -80, 80);
        //x�� ������ ���� x���� �̵��� �ƴ϶� x���� ȸ�� �ؼ� ���Ʒ� ���� ������ x���̿��� �Ѵ�.

        //2. ȸ���� �Ѵ�.
        transform.eulerAngles = new Vector3(-rotX, rotY, 0);


    
    }


    public void MouseMoveFuction()
    {
        // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
        float yRotateSize = Input.GetAxis("Mouse X") * turning_speed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * turning_speed;
        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
        // Clamp �� ���� ������ �����ϴ� �Լ�
        //xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        transform.eulerAngles = new Vector3(0, yRotate, 0);

    }
    void MoveLookAt()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turning_speed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = transform.eulerAngles.y + yRotateSize;
        //����ī�޶� �ٶ󺸴� �����Դϴ�.

        //Vector3 dir = cam.transform.localRotation * Vector3.forward;
        ////ī�޶� �ٶ󺸴� �������� �Ѹǵ� �ٶ󺸰� �մϴ�.
        //transform.localRotation = cam.transform.localRotation;
        ////�Ѹ��� Rotation.x���� freeze�س������� �������� ���� Rotation���� 0���� �������־����ϴ�.
        //transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        ////�ٶ󺸴� ���� �������� �̵��մϴ�.
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
