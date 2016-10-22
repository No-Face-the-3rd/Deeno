using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Vector2 min, max;
    public KeyCode left, right, up, down, primary, secondary;

    public float shots, shotsMax;
    public Vector2 rotAngles;

    public float transSpeed;
    public float primaryDelay, secondaryDelay;
    public float primaryCost, secondaryCost;

    private float primCool = 0.0f, seconCool = 0.0f;
    public int hits;
    public GameObject primaryBullet, secondaryBullet;
    public float shotsRegen;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        primCool += Time.deltaTime;
        seconCool += Time.deltaTime;
	}

    void FixedUpdate()
    {
        Vector3 rot = new Vector3();
        Vector3 trans = new Vector3();
        if(Input.GetKey(right) && transform.position.x < max.x)
        {
            rot.z -= rotAngles.x;
            rot.y -= rotAngles.y;
            trans.x += 1.0f;
        }
        if(Input.GetKey(left) && transform.position.x > min.x)
        {
            rot.z += rotAngles.x;
            rot.y += rotAngles.x;
            trans.x -= 1.0f;
        }
        if(Input.GetKey(up) && transform.position.y < max.y)
        {
            rot.x -= rotAngles.y;
            trans.y += 1.0f;
        }
        if(Input.GetKey(down) && transform.position.y > min.y)
        {
            rot.x += rotAngles.y;
            trans.y -= 1.0f;
        }


        if(Input.GetKey(primary) && shots >= primaryCost && primCool >= primaryDelay)
        {
            shots -= primaryCost;
            primCool = 0.0f;
            GameObject tmp = (GameObject)Instantiate(primaryBullet, transform.position + transform.forward * 1.5f, transform.rotation);
        }
        if(Input.GetKey(secondary) && shots >= secondaryCost && seconCool >= secondaryDelay)
        {
            shots -= secondaryCost;
            seconCool = 0.0f;
            GameObject tmp = (GameObject)Instantiate(secondaryBullet, transform.position + transform.forward * 3.0f, transform.rotation);
        }
        transform.rotation = Quaternion.Euler(rot);
        transform.Translate(trans * transSpeed * Time.deltaTime, Space.World);

        shots += shotsRegen * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hotdog")
        {
            shots += other.GetComponent<ShotsValue>().shotsValue;
            Destroy(other.gameObject);
            SpawnManager.manager.killedPickup();
            if (shots > shotsMax)
            {
                shots = 1.0f;
                hits++;
                if (shotsMax / hits < SpawnManager.manager.getLevel())
                {
                    shotsMax += 10.0f;
                }
            }
        }
        if(other.tag == "Hostile")
        {
            hits--;
            EnemyFire test = other.GetComponent<EnemyFire>();
            if(test != null)
            {

            }
            if (shotsMax / hits > SpawnManager.manager.getLevel())
            {
                shotsMax -= 10.0f;
            }
            Health extraDamage = other.GetComponent<Health>();
            if(extraDamage != null)
            {
                hits -= (extraDamage.health - 1);
                extraDamage.health = 0;
            }
            Destroy(other.gameObject);
        }
        if(other.tag == "HostileBullet")
        {
            Health extraDamage = other.GetComponent<Health>();
            if(extraDamage != null)
            {
                hits -= extraDamage.health;
                extraDamage.health = 0;
            }
        }
    }
}
