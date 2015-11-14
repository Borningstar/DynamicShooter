using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject[] hazards;
    public GameObject spawner;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    // Use this for initialization
    void Start () {

        StartCoroutine(SpawnWaves());

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawner.GetComponent<Renderer>().bounds.max.x, spawner.GetComponent<Renderer>().bounds.max.x), spawner.transform.position.y, spawner.transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawner.transform.rotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

}
