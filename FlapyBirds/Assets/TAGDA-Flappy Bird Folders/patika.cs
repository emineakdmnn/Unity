using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class patika : MonoBehaviour
{

    public bool temasEdildimi;
    public GameObject borular;

    public Text rekor;
    public Text puan;
    // Start is called before the first frame update
    void Start()
    {
        temasEdildimi = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (temasEdildimi)
        {
            temasEdildimi = false;
            Invoke("IleriAta", 5f);
          
        }
    }

    void IleriAta()
    {
        transform.position = transform.position + new Vector3(60, 0, 0);
        float yPoz = Random.Range(-0.166f, 0.713f);

        Debug.Log(yPoz.ToString());
        borular.transform.localPosition = new Vector3(0, yPoz, 0f);
        
    }
}
