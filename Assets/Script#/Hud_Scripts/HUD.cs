using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas;

    // Desactiva una vida en base al indice que se le pase 
    public void UnableLives(int indice)
    {
        vidas[indice].SetActive(false);
    }
}
