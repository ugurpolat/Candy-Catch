using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour {

    [SerializeField]
    float maxX;
    
    public GameObject[] candies;

    [SerializeField]
    float SpawnInterval;

    public static CandySpawner instance;

    private void Awake()
    {
        if (instance == null)
        {

            instance=this;
        }
    }

    // Use this for initialization
    void Start () {

        StartSpawingCandies();


	}
	
	// Update is called once per frame
	void Update () {

        

    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, candies.Length);

        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(candies[rand], randomPos, transform.rotation);


    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnCandy();

            yield return new  WaitForSeconds(SpawnInterval);

        }


    }

    public void StartSpawingCandies()
    {
        StartCoroutine("SpawnCandies");
    }
    public void StopSpawingCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
