using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kusScript : MonoBehaviour
{
    public float hiz;
    public float ziplamaGucu;
    public int puan;
    public GameObject canvas;
    public Text rekor;
    public Text puanText;

    public AudioClip[] sesDosyalari;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
        puan = 0;
    }

    // Update is called once per frame
    void Update()

    {
        //android
        for(var i=0; i < Input.touchCount; ++i)
        {
            if(Input.GetTouch(i).phase== TouchPhase.Began)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
            }
        }



        //pc
       transform.Translate(Vector3.right * hiz * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up*ziplamaGucu);
            GetComponent<AudioSource>().PlayOneShot(sesDosyalari[0], 1);
        }
    }

    void OnTriggerExit2D(Collider2D temas)
    {
        if (temas.gameObject.tag =="Tetik")
        {
           
            temas.gameObject.transform.parent.gameObject.transform.parent.GetComponent<patika>().temasEdildimi = true;
            puan++;
            GetComponent<AudioSource>().PlayOneShot(sesDosyalari[1], 1);
        }
    }
    void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "Engel")
        {
            OyunSonu();
        }
    }
    void OyunSonu()
    {
        Time.timeScale = 0;
        GetComponent<AudioSource>().PlayOneShot(sesDosyalari[2], 1);
        canvas.SetActive(true);

        if (puan>PlayerPrefs.GetInt("rekor"))
        {
            PlayerPrefs.SetInt("rekor",puan);
        }





        puanText.text = puan.ToString();
        rekor.text = PlayerPrefs.GetInt("rekor").ToString();
    }

    public void TekrarButon()

    {
        Application.LoadLevel("enesss");
    }
}
