using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerastript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset;
    private Transform target;
    [Range(0, 10)] public float lerpValue;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y  ,transform.position.z);
    }
}
