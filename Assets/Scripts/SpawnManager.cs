using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
    public static SpawnManager manager;
    public Vector3 minSpawnNear, maxSpawnFar;

    private float curTime;

    private int numPickups = 0, numEnemies = 0, numHazards = 0;
    private int level = 0;

    private GameObject main;
    private GameObject player;
    public GameObject playerPref;
	// Use this for initialization
	void Start () {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if(manager != this)
        {
            Destroy(gameObject);
        }
        main = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }


	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
        if (curTime / 8 > level)
        {
            level++;
        }

        if(numPickups < curTime % level && Random.Range(0.0f,1.0f) < 0.33f)
        {
            spawnPickup();
            spawnPickup();
        }

        if(numEnemies < curTime % level && Random.Range(0.0f,1.0f) < 0.5f)
        {
            spawnEnemy();
        }

        if(numHazards < curTime % level && Random.Range(0.0f,1.0f) < 0.75)
        {
            spawnHazard();
        }

        if(player.GetComponent<PlayerController>().hits <= 0)
        {
            GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
            foreach(GameObject obje in objects)
            {
                if(obje != main && obje.tag != "Finish" && obje != this.gameObject)
                {
                    Destroy(obje);
                }
            }
            player = (GameObject)Instantiate(playerPref, Vector3.zero, Quaternion.Euler(Vector3.zero));
            curTime = 0.0f;
            level = numEnemies = numHazards = numPickups = 0;
        }
	}

    public void killedPickup()
    {
        numPickups--;
    }
    public void killedEnemy()
    {
        numEnemies--;
    }
    public void killedHazard()
    {
        numHazards--;
    }

    public int getLevel()
    {
        return level;
    }

    void spawnPickup()
    {
        Vector3 spawnPos = chooseSpawn();
        int left = level / SpawnDB.spawnDB.getNumPickups(), right = SpawnDB.spawnDB.getNumPickups();
        int ind = Random.Range(0, left <= right ? left : right);
        GameObject pickup = (GameObject)Instantiate(SpawnDB.spawnDB.getPickup(ind), spawnPos, Quaternion.Euler(Vector3.zero));
        pickup.transform.forward = player.transform.position - spawnPos;
        numPickups++;
    }
    void spawnEnemy()
    {
        Vector3 spawnPos = chooseSpawn();
        int left = level / SpawnDB.spawnDB.getNumEnemies(), right = SpawnDB.spawnDB.getNumEnemies();
        int ind = Random.Range(0, left <= right ? left : right);
        GameObject enemy = (GameObject)Instantiate(SpawnDB.spawnDB.getEnemy(ind), spawnPos, Quaternion.Euler(Vector3.zero));
        enemy.transform.forward = player.transform.position - spawnPos;
        numEnemies++;
    }
    void spawnHazard()
    {
        Vector3 spawnPos = chooseSpawn();
        int left = level / SpawnDB.spawnDB.getNumHazards(), right = SpawnDB.spawnDB.getNumHazards();
        int ind = Random.Range(0, left <= right ? left : right);
        GameObject hazard = (GameObject)Instantiate(SpawnDB.spawnDB.getHazard(ind), spawnPos, Quaternion.Euler(Vector3.zero));
        hazard.transform.forward = main.transform.position - spawnPos;
        numHazards++;
    }

    Vector3 chooseSpawn()
    {
        Vector3 absNear = Abs(minSpawnNear), absFar = Abs(maxSpawnFar);
        Vector3 sub = absFar - absNear;
        float ease = 1.0f / level;
        float minRange = absNear.z + ease * sub.z;
        Vector3 ret = new Vector3(0, 0, Random.Range(minRange, absFar.z));
        float t = (ret.z - absNear.z) / sub.z;
        Vector2 min = new Vector2(minSpawnNear.x - t * sub.x, minSpawnNear.y - t * sub.y), max = new Vector2(maxSpawnFar.x - t * sub.y, maxSpawnFar.y - t * sub.y);
        ret.x = Random.Range(min.x, max.x);
        ret.y = Random.Range(min.y, max.y);
        return ret;
    }

    Vector3 Abs(Vector3 inVec)
    {
        Vector3 outVec = new Vector3(Mathf.Abs(inVec.x), Mathf.Abs(inVec.y), Mathf.Abs(inVec.z));
        return outVec;
    }

    public GameObject getPlayer()
    {
        return player;
    }
}
