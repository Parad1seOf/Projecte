using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableItem : MonoBehaviour
{
    public GM_Item thisobject;
    
    [SerializeField] private AudioClip colectar1;

    private void Awake() {
        thisobject = GetComponent<GM_Item>();    
    }

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

            if (ControladorSonido.Instance != null)
            {
                ControladorSonido.Instance.EjecutarSonido(colectar1);
            }
            else
            {
                Debug.LogError("ControladorSonido instance is null");
            }
        }
    }
}
