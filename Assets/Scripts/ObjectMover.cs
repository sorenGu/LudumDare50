using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {
    List<Transform> randomObjects = new List<Transform>();
    List<Transform> pathObjects = new List<Transform>();

    public List<GameObject> pathSegments;
    float pathStart = -10f;

    float speed = 5f;
    Vector3 direction = new Vector3(0, 0, -1);


    void Start() {
        SpawnPath();
    }

    private void SpawnPath() {
        for (int i = 0; i <= 4; i++) {
            Vector3 postion = new Vector3(0, 0, pathStart + 10 * i);
            AddPathSegment(postion);

        }
    }
    // TODO move objects as groups
    void Update() {
        bool wasDestroyed = false;
        for (var i = pathObjects.Count - 1; i > -1; i--) {
            if (moveObject(pathObjects[i])) {
                wasDestroyed = true;
                pathObjects.RemoveAt(i);
            }
        }
        if (wasDestroyed) {

        }
    }

    private void AddPathSegment(Vector3 postion) {
        GameObject _path = Instantiate(pathSegments[UnityEngine.Random.Range(0, pathSegments.Count)], postion, Quaternion.identity);
        pathObjects.Add(_path.transform);
    }

    private bool moveObject(Transform element) {
        element.Translate(direction * speed * Time.deltaTime);
        if (element.position.z <= -12f) {
            Destroy(element.gameObject);
            return true;
        }
        return false;
    }
}
