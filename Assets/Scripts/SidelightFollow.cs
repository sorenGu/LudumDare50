using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidelightFollow : MonoBehaviour
{
    public GameObject FriendObject;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(FriendObject.transform);
    }
}
