using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameController gameController;
    public List<Transform> foods;

    float eatDistance = 2f;

    private void OnEnable() {
        gameController = transform.parent.GetComponent<GameController>();
    }

    void Update() {
        CheckDistance();
        transform.Translate(Vector3.forward * Time.deltaTime * (float)(gameController.gameSpeed * 0.05));
    }

    private void CheckDistance() {
        foreach(Transform food in foods) {
            float distance = (transform.position - food.position).sqrMagnitude;
            if (distance < eatDistance) {
                gameController.GameOver();
            } else if (distance < eatDistance * 4) {
                // TODO spookier sounds and new animation
            } else {
                // TODO rotate to normal (delegate)
            }
        }
    }
}
