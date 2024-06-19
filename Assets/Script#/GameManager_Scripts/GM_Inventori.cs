using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Inventori : MonoBehaviour
{
    public List<GM_Item> items = new List<GM_Item>();
    public static GM_Inventori instance;

    // Si no hay una instancia de GM_Inventori, se crea una y se mantiene en todas las escenas
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Agrega un objeto al inventario
    public void AddItem(GM_Item thisobject) {
        items.Add(thisobject);
    }
    // Elimina un objeto del inventario
    public void RemoveItem(GM_Item item) {
        items.Remove(item);
    }
    // Verifica si un objeto esta en el inventario
    public bool HasItem(GM_Item item) {
        return items.Contains(item);
    }
}
