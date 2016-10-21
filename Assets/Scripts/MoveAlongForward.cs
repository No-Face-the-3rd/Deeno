using UnityEngine;
using System.Collections;

public class MoveAlongForward : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Vector3 trans = Vector3.forward * (speed * Time.deltaTime);
        transform.Translate(trans);
    }
}
