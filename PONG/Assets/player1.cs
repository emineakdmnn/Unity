using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    public float hiz;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(0f, hiz * Time.deltaTime, 0f); //nesnenin pozisyonunu değiştirmeye yarıyor
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, -hiz * Time.deltaTime, 0f); //nesnenin pozisyonunu değiştirmeye yarıyor
        }
    }

}
