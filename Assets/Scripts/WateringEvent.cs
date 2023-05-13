using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringEvent : MonoBehaviour
{
    private float waterEventTimer;
    private float plantGrowthTime;
    private float currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        waterEventTimer = plantGrowthTime / 2;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > waterEventTimer)
        {

        }
    }
}
