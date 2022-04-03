using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour {
    public GameObject currentItem;

    internal bool AddItem(string new_item) {
        if (!currentItem.activeSelf) {
            currentItem.SetActive(true);
            return true;
        }
        return false;
    }
}
