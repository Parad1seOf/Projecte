using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableItem : MonoBehaviour
{
    public GM_Item thisobject;
    
    [SerializeField] private AudioClip colect1;

    // Inicializa el objeto
    private void Awake() 
    {
        thisobject = GetComponent<GM_Item>();    
    }
    // Si el jugador colisiona con el objeto, se destruye y se agrega al inventario
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with collectible");

            Destroy(gameObject);

            if (GM_Inventori.instance != null)
            {
                GM_Inventori.instance.AddItem(thisobject);
            }
            else
            {
                Debug.LogError("GM_Inventori instance is null");
            }

            if (SoundController.Instance != null)
            {
                SoundController.Instance.EjecutarSonido(colect1);
            }
            else
            {
                Debug.LogError("SoundController instance is null");
            }
        }
    }
}
