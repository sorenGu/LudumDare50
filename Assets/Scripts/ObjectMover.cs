using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {
    List<Transform> randomObjects = new List<Transform>();
    List<Transform> pathObjects = new List<Transform>();

    public List<GameObject> pathSegments;
    float pathStart = -45f;

    float speed = 5f;


    void Start() {
        SpawnPath();
    }

    private void SpawnPath() {
        for(int i = 0; i <= 4; i++) {
            GameObject _path = Instantiate(pathSegments[UnityEngine.Random.Range(0, pathSegments.Count)], new Vector3(0,0, pathStart + 10 * i), Quaternion.identity);
            pathObjects.Add(_path.transform);            
        }
    }

    // Update is called once per frame
    void Update() {
        foreach (Transform element in pathObjects) {
            bool wasDestroyed = moveObject(element);
        }
        
    }

    private bool moveObject(Transform element) {
        element.Translate(Vector3.forward * speed * Time.deltaTime);
        if (element)
    }
}
