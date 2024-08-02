using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // ��������� "�� �����" � "� ������"
    public bool isGrounded = true;
    public bool isJumping = false;

    // ������� ���������� ������ ���������
    Rigidbody playerRb;

    // ������� ���������� ������ ��������
    Collider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        // ����������� ���������� ��������� 
        // � ���������� ��������� ������� � ������� ���������� ������
        playerRb = GetComponent<Rigidbody>();

        // ����������� ���������� �������� 
        // � ���������� ��������� ������� � ������� ���������� ������
        playerCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded && !isJumping)
            {
                // ����� ��������� ��������� ��������� ������������ �������� �������
                playerRb.velocity = Vector3.up * 10;

                // ��������� � ��������� ������
                isJumping = true;
                isGrounded = false;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") == true)
        {
            isGrounded = true;
            isJumping = false;
        }
    }
}
