using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

    public float faceDelay;
    private float coolFace = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (coolFace > faceDelay)
        {
            transform.forward = SpawnManager.manager.getPlayer().transform.position - transform.position;
            coolFace = 0.0f;
        }
        coolFace += Time.deltaTime;
	}
}
