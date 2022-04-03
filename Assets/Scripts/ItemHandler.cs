using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour {
    public GameObject currentItem;

    public Transform friend;
    public ItemReceiver friendItemReceiver;
    float eatDistance = 4f;

    Action currentAction;

    private void OnEnable() {
        currentAction = NothingToDo;
    }
    private void Update() {
        currentAction();
    }

    private void NothingToDo() {}

    internal bool AddItem(string new_item) {
        if (!currentItem.activeSelf) {
            currentItem.SetActive(true);
            currentAction = CheckDistance;
            return true;
        }
        return false;
    }

    public void CheckDistance() {
        float distance = distance = (transform.position - friend.position).sqrMagnitude;

        if (distance < eatDistance) {
            friendItemReceiver.ReceiveItem();
            currentItem.SetActive(false);
            currentAction = NothingToDo;
        }

    }
}
