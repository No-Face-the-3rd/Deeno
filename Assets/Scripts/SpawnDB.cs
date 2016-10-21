using UnityEngine;
using System.Collections;

public class SpawnDB : MonoBehaviour {

    [SerializeField]
    private GameObject[] pickups, enemies, hazards;

    public static SpawnDB spawnDB;

	// Use this for initialization
	void Start () {
	    if(spawnDB == null)
        {
            DontDestroyOnLoad(gameObject);
            spawnDB = this;
        }
        else if(spawnDB != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject getPickup(int ind)
    {
        return pickups[ind];
    }

    public int getNumPickups()
    {
        return pickups.Length;
    }

    public GameObject getEnemy(int ind)
    {
        return enemies[ind];
    }

    public int getNumEnemies()
    {
        return enemies.Length;
    }

    public GameObject getHazard(int ind)
    {
        return hazards[ind];
    }

    public int getNumHazards()
    {
        return hazards.Length;
    }
}
