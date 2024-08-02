using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // состояние "На земле" и "В прыжке"
    public bool isGrounded = true;
    public bool isJumping = false;

    // создаем переменную класса ригидбади
    Rigidbody playerRb;

    // создаем переменную класса колайдер
    Collider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        // привязываем переменную ригидбади 
        // к компоненту ригидбади объекта к кторому прикреплен скрипт
        playerRb = GetComponent<Rigidbody>();

        // привязываем переменную колайдер 
        // к компоненту ригидбади объекта к кторому прикреплен скрипт
        playerCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded && !isJumping)
            {
                // через компонент ригидбади добавляем вертикальную скорость объекту
                playerRb.velocity = Vector3.up * 10;

                // переходим в состояние прыжка
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
