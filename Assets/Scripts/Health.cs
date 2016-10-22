using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public int health;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn" || (other.tag == "Hostile" && (this.tag != "HostileBullet" && this.tag != "Hostile")))
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), other);
            health--;
        }
    }
}
