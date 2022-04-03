using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceiver : MonoBehaviour {
    public Action OnReceiveItem;
    public GameObject pentagram;

    internal void ReceiveItem() {
        pentagram.SetActive(true);
        OnReceiveItem?.Invoke();
    }
}
