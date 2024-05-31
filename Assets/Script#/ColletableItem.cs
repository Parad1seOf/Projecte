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

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) {
            // Debug.Log("Item Collected");
            Destroy(gameObject);
            GM_Inventori.instance.AddItem(thisobject);
            
            ControladorSonido.Instance.EjecutarSonido(colectar1);
        }

     
    }
}
