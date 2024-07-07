using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaras : MonoBehaviour
{
    public GameObject [] ListaCamaras;
    // Start is called before the first frame update
    void Start()
    {
        ListaCamaras[0].gameObject.SetActive(true);
        ListaCamaras[1].gameObject.SetActive(false);
        ListaCamaras[2].gameObject.SetActive(false);
        ListaCamaras[3].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1)) {
             ListaCamaras[0].gameObject.SetActive(true);
             ListaCamaras[1].gameObject.SetActive(false);
             ListaCamaras[2].gameObject.SetActive(false);
             ListaCamaras[3].gameObject.SetActive(false);
             Debug.Log("Tecla pulsada 1");
    }
    if (Input.GetKey(KeyCode.Alpha2)) {
        ListaCamaras[0].gameObject.SetActive(false);
        ListaCamaras[1].gameObject.SetActive(true);
        ListaCamaras[2].gameObject.SetActive(false);
        ListaCamaras[3].gameObject.SetActive(false);
              Debug.Log("Tecla pulsada 2");
    }
    if (Input.GetKey(KeyCode.Alpha3)) {
         ListaCamaras[0].gameObject.SetActive(true);
         ListaCamaras[1].gameObject.SetActive(false);
         ListaCamaras[2].gameObject.SetActive(true);
         ListaCamaras[3].gameObject.SetActive(false);
              Debug.Log("Tecla pulsada 3");
    }
    if (Input.GetKey(KeyCode.Alpha4)) {
         ListaCamaras[0].gameObject.SetActive(true);
         ListaCamaras[1].gameObject.SetActive(false);
         ListaCamaras[2].gameObject.SetActive(false);
         ListaCamaras[3].gameObject.SetActive(true);
              Debug.Log("Tecla pulsada 4");
    }
    }
}
