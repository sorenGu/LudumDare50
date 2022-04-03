using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    void Update() {
        // TODO rotate
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.GetComponent<ItemHandler>().AddItem("Pentagram");
        }
    }

}
