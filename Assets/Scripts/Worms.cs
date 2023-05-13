using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worms : MonoBehaviour
{
    public float wormSpawnTime;
    private float plantGrowthTime;
    private float currentTime;
    public GameObject worm;

    // Start is called before the first frame update
    void Start()
    {
        wormSpawnTime = Random.Range(0, plantGrowthTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > wormSpawnTime)
        {
            InstantiateWorm();
        }
    }

    public void InstantiateWorm()
    {
        Instantiate(worm, transform.position, transform.rotation);
        wormSpawnTime = Random.Range(0, plantGrowthTime);
    }
}
