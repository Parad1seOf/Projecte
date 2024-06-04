using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public HUD hud;
    private int vidas = 5;
        
    public void PerderVida()
    {
        vidas -= 1;
        hud.DesactivarVidas(vidas);
    }

}
