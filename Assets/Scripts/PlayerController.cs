using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float rotationSpeed = 7f;
    GameController gameController;
    Rigidbody m_Rigidbody;

    private void OnEnable() {
        gameController = transform.parent.GetComponent<GameController>();
        gameController.OnGameOver += OnGameOver;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnGameOver() {
        Destroy(this);
    }

    void FixedUpdate() {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();

        if (direction != Vector3.zero) {
            m_Rigidbody.MovePosition(transform.position + direction * Time.deltaTime *  gameController.gameSpeed * 2);
            /* TODO walk/run animation */
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotationSpeed
            );
        } else {
            // TODO idle animation
            m_Rigidbody.MovePosition(transform.position + gameController.downDirection * Time.deltaTime *  gameController.gameSpeed);
        }
        // TODO what when out of screen?
    }
}
