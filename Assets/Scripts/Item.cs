using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    void Update() {
        transform.Rotate(0f, 0.3f, 0.0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (other.GetComponent<ItemHandler>().AddItem("Pentagram")) {
                Destroy(gameObject);
            }
        }
    }

}
