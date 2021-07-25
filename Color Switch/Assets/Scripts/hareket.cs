using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using TMPro;

public class hareket : MonoBehaviour
{

    public Rigidbody2D top;
    public float ziplamaGucu;

    public Color turkuazRenk, sariRenk, morRenk, pembeRenk;
    public string mevcutRenk;
    public SpriteRenderer ressam;
    public Transform degistirici;
    public TextMeshProUGUI skorYazisi;
    public int skor;
    public Transform kontrol1, kontrol2, cember1, cember2;
    public AudioSource ziplamaSesi;
   
    void Start()
    {
        dondurme.donusHizi = 0.5f;
        RastgeleRenk ();
    }
    void Update()
    {
        skorYazisi.text = "Skor : " + skor;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            top.velocity = Vector2.up * ziplamaGucu;
            ziplamaSesi.Play();
        }

        //android
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.tag != mevcutRenk && temas.tag != "RenkDegistirici" && temas.tag != "Kontrol1" && temas.tag != "Kontrol2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Aktif sahneyi yeniden baþlatýyoruz
        }

        if (temas.tag == "RenkDegistirici")
        {
            skor++;
            degistirici.position = new Vector3(degistirici.position.x, degistirici.position.y + 8f, degistirici.position.z);
          //  Destroy(temas.gameObject); // temas ettiði objeyi yok ediyo
            RastgeleRenk();
            dondurme.donusHizi += 0.2f;

        }

        if (temas.tag=="Kontrol1")
        {
            kontrol1.position = new Vector3(kontrol1.position.x, kontrol1.position.y + 16f, kontrol1.position.z);
            cember1.position = new Vector3(cember1.position.x, cember1.position.y + 16f, cember1.position.z);
        }

        if (temas.tag == "Kontrol2")
        {
            kontrol2.position = new Vector3(kontrol2.position.x, kontrol2.position.y + 16f, kontrol2.position.z);
            cember2.position = new Vector3(cember2.position.x, cember2.position.y + 16f, cember2.position.z);
        }
    }

    void RastgeleRenk()
    {
        int rastgele = Random.Range(0, 4);
        switch (rastgele)
        {
            case 0:
                mevcutRenk = "Turkuaz";
                ressam.color = turkuazRenk;
                break;

            case 1:
                mevcutRenk = "Sari";
                ressam.color = sariRenk;
                break;

            case 2:
                mevcutRenk = "Mor";
                ressam.color = morRenk;
                break;

            case 3:
                mevcutRenk = "Pembe";
                ressam.color = pembeRenk;
                break;
        }
    }
}
