using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject gameObjectToFollow;
    private Vector3 currentPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.currentPosition = this.gameObjectToFollow.transform.position;
        this.currentPosition.x += 1;
        this.transform.position = this.currentPosition;
    }
}