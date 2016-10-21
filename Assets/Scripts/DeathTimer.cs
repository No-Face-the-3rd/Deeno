using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour {

    public float timeToDie;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (timeToDie <= 0.0f)
            Destroy(gameObject);
        timeToDie -= Time.deltaTime;
	}
}
