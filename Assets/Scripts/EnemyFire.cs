using UnityEngine;
using System.Collections;

public class EnemyFire : MonoBehaviour {

    public float delayShot;
    public GameObject bullet;

    private float coolTime = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(coolTime > delayShot)
        {
            GameObject tmp = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
            coolTime = 0.0f;
            Physics.IgnoreCollision(GetComponent<Collider>(), tmp.GetComponent<Collider>());
        }
        coolTime += Time.deltaTime;	
	}
}
