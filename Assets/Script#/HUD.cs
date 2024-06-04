using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas;

    public void DesactivarVidas(int indice)
    {
        vidas[indice].SetActive(false);
    }


}
