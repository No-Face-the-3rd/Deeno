using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector2 min, max;
    public KeyCode left, right, up, down;

    public float shots;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void FixedUpdate()
    {
        Vector3 rot = transform.eulerAngles;
        Vector3 pos = new Vector3();
        if(Input.GetKey(left) && transform.position.x > min.x)
        {

        }
    }
}
