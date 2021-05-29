using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kareler : MonoBehaviour
{

     MeshRenderer ressam;
    public Material sari, kirmizi, yesil, mavi, turuncu;
    public AudioSource renkSesi;
    void Start()
    {
        ressam = GetComponent<MeshRenderer>();
        RenkVer();
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RenkVer();
            renkSesi.Play();
        }
    }

    void RenkVer()
    {
        int rastgele = Random.Range(1, 6);
        switch (rastgele)
        {
            case 1:
                ressam.material = sari;
                break;
            case 2:
                ressam.material = kirmizi;
                break;
            case 3:
                ressam.material = yesil;
                break;
            case 4:
                ressam.material = mavi;
                break;
            case 5:
                ressam.material = turuncu;
                break;

        }

       
    }
}
