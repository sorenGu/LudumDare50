using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagramOnFriend : MonoBehaviour {

    float highlightTimer = 2f;
    private void OnEnable() {
        highlightTimer = 2f;
    }

    private void Update() {
        if (highlightTimer <= 0) {
            gameObject.SetActive(false);
        } else {
            highlightTimer -= Time.deltaTime;
        }
    }
}
