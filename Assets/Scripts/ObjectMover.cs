using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {
    List<Transform> randomObjects = new List<Transform>();
    List<Transform> pathObjects = new List<Transform>();

    public Transform playerTransform;

    public List<GameObject> pathSegments;
    float pathLength = 10f;

    GameController gameController;

    private void OnEnable() {
        gameController = GetComponent<GameController>();
    }

    void Start() {
        SpawnPath();
    }

    private void SpawnPath() {
        /* ToDo: 
        Erster Tile soll etwas schoener / anders sein
        */
        for (int i = 0; i <= 6; i++) {
            Debug.Log(-pathLength);
            Debug.Log(pathLength * i);
            Vector3 postion = new Vector3(0, 0, -pathLength + (pathLength * i));
            AddPathSegment(postion);
        }
    }

    void Update() {
        movePath();
    }

    private void movePath() {
        bool wasDestroyed = false;
        for (var i = pathObjects.Count - 1; i > -1; i--) {
            if (moveObject(pathObjects[i])) {
                wasDestroyed = true;
                pathObjects.RemoveAt(i);
            }
        }
        if (wasDestroyed) {
            AddPathSegment(pathObjects[pathObjects.Count - 1].position + new Vector3(0, 0, pathLength));
        }
    }

    private void AddPathSegment(Vector3 postion) {
        GameObject _path = Instantiate(pathSegments[UnityEngine.Random.Range(0, pathSegments.Count)], postion, Quaternion.identity);
        pathObjects.Add(_path.transform);
    }

    private bool moveObject(Transform element) {
        element.Translate(gameController.downDirection * gameController.gameSpeed * Time.deltaTime);
        if (element.position.z <= -12f) {
            Destroy(element.gameObject);
            return true;
        }
        return false;
    }
}
