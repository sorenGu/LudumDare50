using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float rotationSpeed = 7f;
    GameController gameController;
    CharacterController controller;

    private void OnEnable() {
        gameController = transform.parent.GetComponent<GameController>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();

        if (direction != Vector3.zero) {
            controller.Move(direction * Time.deltaTime * gameController.gameSpeed * 2);
            /* TODO walk/run animation */
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotationSpeed
            );
        } else {
            // TODO idle animation
            transform.Translate( gameController.downDirection * (gameController.gameSpeed * Time.deltaTime), Space.World);
        }
        // TODO what when out of screen?
    }
}
