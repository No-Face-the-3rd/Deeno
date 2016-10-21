using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public Vector3 rotSpeeds;

    private Vector3 rot;

	// Use this for initialization
	void Start () {
        rot = transform.rotation.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        rot += rotSpeeds * Time.deltaTime;
        transform.eulerAngles = rot;

    }
}
