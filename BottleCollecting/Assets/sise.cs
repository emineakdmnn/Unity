using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sise : MonoBehaviour
{
    public Transform sise2;
    public TextMeshProUGUI canYazisi,bitisYazisi;
    public int can;
    public AudioSource siseDusurme;

    void Update()
    {
        canYazisi.text = "Can : " + can;

        if (can == 0)
        {
            bitisYazisi.text = "OYUN BÝTTÝ TEKRAR BASLAMAK ÝÇÝN  TUSA BASIN ";
            Time.timeScale = 0;

            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D temas)
    {

        float rastgele = Random.Range(-8f, 8f);  

        if (temas.gameObject.tag == "zemin")
        {

            sise2.position = new Vector3(rastgele, 6f, 0f);
            can--;
            siseDusurme.Play();
        }
    }
}
