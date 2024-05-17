using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Inventori : MonoBehaviour
{
    public List<GM_Item> items = new List<GM_Item>();
    public static GM_Inventori instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void AddItem(GM_Item thisobject) {
        items.Add(thisobject);
    }

    public void RemoveItem(GM_Item item) {
        items.Remove(item);
    }

    public bool HasItem(GM_Item item) {
        return items.Contains(item);
    }
}
