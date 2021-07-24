using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class tophareketleri : MonoBehaviour
{
    public Rigidbody2D top;
    public float xHizi, yHizi;
    public TextMeshProUGUI player1Yazi, player2Yazi,kazananYazisi,bitisYazisi;
    int player1Skor, player2Skor;
    public int maxSkor;
    public AudioSource skorSesi, kazanmaSesi;
    
    void Update()
    {
        player1Yazi.text = player1Skor.ToString();
        player2Yazi.text = player2Skor.ToString();
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            
        }
    }

   
    void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag=="Player1")
        {
            top.velocity = new Vector2(-xHizi, Random.Range(-3.5f,3.5f));
        }
        else if (temas.gameObject.tag == "Player2")
        {
            top.velocity = new Vector2(xHizi, Random.Range(-3.5f, 3.5f));
        }

        if (temas.gameObject.tag=="UstDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, -yHizi);
        }
       else if (temas.gameObject.tag == "AltDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, yHizi);
        }

        if (temas.gameObject.tag=="SolDuvar")
        {
            player1Skor++;
            transform.position = new Vector2(-8.095f,0f);
            skorSesi.Play();
        }else if (temas.gameObject.tag == "SagDuvar")
        {
            player2Skor++;
            transform.position = new Vector2(8.095f, 0f);
            skorSesi.Play();
        }

        if (player1Skor==maxSkor)
        {
            kazananYazisi.text = "Player 1 Win";
            bitisYazisi.text = "Tekrar Oynamak Icin Enter'a Basiniz!";
            kazanmaSesi.Play();
            Time.timeScale = 0; // oyunun hýzýný 0 a düþürüyoruz.
        } else if(player2Skor == maxSkor)
        {
            kazananYazisi.text = "Player 2 Win";
            bitisYazisi.text = "Tekrar Oynamak Icin Enter'a Basiniz!";
            kazanmaSesi.Play();
            Time.timeScale = 0;
        }
        
    }
}
