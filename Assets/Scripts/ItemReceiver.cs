using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceiver : MonoBehaviour {
    public Action OnReceiveItem;

    internal void ReceiveItem() {
        //TODO animate
        OnReceiveItem?.Invoke();
    }
}
