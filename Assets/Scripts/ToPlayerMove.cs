using UnityEngine;
using System.Collections;

public class ToPlayerMove : MonoBehaviour {

    private Vector3 direction;

    public float moveSpeed;
    // Use this for initialization
    void Start () {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        direction = player.transform.position - transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }
}
