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

    public Camera cam; //����ī�޶�



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

        transform.localPosition += dir * movespeed * Time.deltaTime;
        transform.localPosition += uping * reverse_gravity * Time.deltaTime;

        //MouseMoveFuction();
        MoveLookAt();

        //transform.position += dir * movespeed * Time.deltaTime;
        //transform.position += uping * reverse_gravity * Time.deltaTime;


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



        Vector3 dir = cam.transform.localRotation * Vector3.forward;
        //ī�޶� �ٶ󺸴� �������� �Ѹǵ� �ٶ󺸰� �մϴ�.
        transform.localRotation = cam.transform.localRotation;
        //�Ѹ��� Rotation.x���� freeze�س������� �������� ���� Rotation���� 0���� �������־����ϴ�.
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);
        //�ٶ󺸴� ���� �������� �̵��մϴ�.
        gameObject.transform.Translate(dir * 0.1f * Time.deltaTime);





        transform.eulerAngles = new Vector3(0, yRotate, 0);

    }

}
