using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;

public class ShopMenuController : MonoBehaviour
{
    [Header("Plant Limit")]
    public int plantLimit = 1;

    [Header("Money")]
    public Text cashAmt;
    public float moneyAmt = 1000;

    [Header("Tab Buttons Text")]
    public Text vegetablesBtn;
    public Text decorativesBtn;
    public Text herbsBtn;

    [Header("Tabs")]
    public GameObject vegeTab;
    public GameObject decoTab;
    public GameObject herbTab;

    [Header("Vegetable Buy Buttons")]
    public GameObject cornBtn;
    public GameObject cucumberBtn;
    public GameObject tomatoBtn;
    public GameObject turnipBtn;
    public GameObject cabbageBtn;

    [Header("Decorative Buy Buttons")]
    public GameObject sunflowerBtn;
    public GameObject marigoldBtn;
    public GameObject lavenderBtn;
    public GameObject coneflowerBtn;

    [Header("Herb Buy Buttons")]
    public GameObject cilantroBtn;
    public GameObject thymeBtn;
    public GameObject rosemaryBtn;
    public GameObject mintBtn;

    [Header("Plants Prefab")]
    public GameObject halfCornPrefab;
    public GameObject fullCornPrefab;
    public GameObject halfCucumberPrefab;
    public GameObject halfTomatoPrefab;
    public GameObject halfTurnipPrefab;
    public GameObject halfCabbagePrefab;
    public GameObject halfSunflowerPrefab;
    public GameObject halfMarigoldPrefab;
    public GameObject halfLavenderPrefab;
    public GameObject halfConeflowerPrefab;
    public GameObject halfCilantroPrefab;
    public GameObject halfThymePrefab;
    public GameObject halfRosemaryPrefab;
    public GameObject halfMintPrefab;

    [Header("Progress Bar")]
    public GameObject bar;
    public GameObject harvestMessage;
    public GameObject waterMessage;
    public GameObject wateringCan;
    public GameObject fertilizeMessage;
    public Animator wateringAnim;
    public GameObject worm;
    public GameObject progressBar;

    [Header("Plant Prices")]
    public float CornPrice;
    public float CornProfit;
    public float CucumberPrice;
    public float CucumberProfit;
    public float TomatoPrice;
    public float TomatoProfit;
    public float TurnipPrice;
    public float TurnipProfit;
    public float CabbagePrice;
    public float CabbageProfit;
    public float SunflowerPrice;
    public float SunflowerProfit;
    public float MarigoldPrice;
    public float MarigoldProfit;
    public float LavenderPrice;
    public float LavenderProfit;
    public float ConeflowerPrice;
    public float ConeflowerProfit;
    public float ClinatroPrice;
    public float ClinatroProfit;
    public float ThymePrice;
    public float ThymeProfit;
    public float RosemaryPrice;
    public float RosemaryProfit;
    public float MintPrice;
    public float MintProfit;

    [Header("Plant Growth Time")]
    public float CornTime;
    public float CucumberTime;
    public float TomatorTime;
    public float TurnipTime;
    public float CabbageTime;
    public float SunflowerTime;
    public float MarigoldTime;
    public float LavenderTime;
    public float ConeflowerTime;
    public float ClinatroTime;
    public float ThymeTime;
    public float RosemaryTime;
    public float MintTime;

    int plantAmt;
    //public static string boughtItem;
    public static bool boughtSmtg = false;
    string boughtPlant;
    string dollarSign = "$";
    InGameUIController gameUIController;
    GameObject flowerPot;
    GameObject instantiatedPlant;
    GameObject tempPot;
    GameObject halfPlant;
    GameObject fullPlant;
    float waterEventTime;
    float currentTime;
    private Animation anim;
    float wormSpawnTime;
    float profit;
    float plantGrowthTime;
    GameObject instantiatedWateringCan;
    
    void Start()
    {
        gameUIController = GetComponent<InGameUIController>();
        flowerPot = GameObject.FindGameObjectWithTag("FlowerPot");
        tempPot = GameObject.FindGameObjectWithTag("FlowerPotObject");
    }

    void Update()
    {
        cashAmt.text = dollarSign + moneyAmt;

        if (!fertilizeMessage.active && !waterMessage.active && !worm.active)
        {
            currentTime += Time.deltaTime;
        }
        if (waterEventTime != 0f && currentTime > waterEventTime)
        {
            waterMessage.SetActive(true);
            LeanTween.pause(bar);
        }

        if (wormSpawnTime != 0f && currentTime > wormSpawnTime)
        {        
            InstantiateWorm();
            LeanTween.pause(bar);
        }

        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    if (worm.active)
                    {
                        worm.SetActive(false);
                        LeanTween.resume(bar);
                    }
                    if (currentTime > plantGrowthTime)
                    {
                        Destroy(instantiatedPlant);
                        moneyAmt += profit;
                        tempPot.SetActive(true);
                        harvestMessage.SetActive(false);
                        LeanTween.scaleX(bar, 0, 0);
                        progressBar.SetActive(false);
                        plantAmt--;
                        InGameUIController.potUsed = false;
                        currentTime = 0f;
                    }
                }
            }
        }
        if (boughtSmtg && plantAmt <= plantLimit)
        {
            tempPot.SetActive(false);
            //Destroy(tempPot);
            //instantiatedPlant.transform.localPosition = new Vector3(0f, 0.85f, -0.1f);
            //instantiatedPlant.transform.localScale = new Vector3(1f, 1f, 1f);
            boughtSmtg = false;
        }
        
    }

    public void VegeTabBtn()
    {
        vegetablesBtn.color = Color.blue;
        decorativesBtn.color = Color.black;
        herbsBtn.color = Color.black;
        vegeTab.SetActive(true);
        decoTab.SetActive(false);
        herbTab.SetActive(false);

    }
    public void DecoTabBtn()
    {
        vegetablesBtn.color = Color.black;
        decorativesBtn.color = Color.blue;
        herbsBtn.color = Color.black;
        vegeTab.SetActive(false);
        decoTab.SetActive(true);
        herbTab.SetActive(false);
    }
    public void HerbTabBtn()
    {
        vegetablesBtn.color = Color.black;
        decorativesBtn.color = Color.black;
        herbsBtn.color = Color.blue;
        vegeTab.SetActive(false);
        decoTab.SetActive(false);
        herbTab.SetActive(true);
    }

    public void BoughtCorn()
    {
        if(plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfCornPrefab;
            fullPlant = fullCornPrefab;
            profit = CornProfit;
            plantGrowthTime = CornTime;
            moneyAmt -= CornPrice;
            instantiatedPlant = Instantiate(halfCornPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtCucumber()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 20f;
            instantiatedPlant = Instantiate(halfCucumberPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtTomato()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 20f;
            instantiatedPlant = Instantiate(halfTomatoPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtTurnip()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfTurnipPrefab, flowerPot.transform);
            boughtSmtg = true;

        }
    }
    public void BoughtCabbage()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 30f;
            instantiatedPlant = Instantiate(halfCabbagePrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtSunflower()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfSunflowerPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtMarigold()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfMarigoldPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtLavender()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfLavenderPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtConeflower()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfConeflowerPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtCilantro()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfCilantroPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtThyme()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfThymePrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtRosemary()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfRosemaryPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }
    public void BoughtMint()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            moneyAmt -= 10f;
            instantiatedPlant = Instantiate(halfMintPrefab, flowerPot.transform);
            boughtSmtg = true;
        }
    }

    //Progress Bar
    public void AnimateBar(float plantGrowthTime)
    {
        waterEventTime = plantGrowthTime / 2;
        wormSpawnTime = Random.Range(waterEventTime, plantGrowthTime);
        progressBar.SetActive(true);
        LeanTween.scaleX(bar, 1, plantGrowthTime).setOnComplete(GrowPlant);
        currentTime = 0f;
        fertilizeMessage.SetActive(true);
        LeanTween.pause(bar);
        
    }

    void GrowPlant()
    {
        harvestMessage.SetActive(true);
        Destroy(instantiatedPlant);
        instantiatedPlant = Instantiate(fullPlant, flowerPot.transform);
    }

    public void WaterPlant()
    {
        if (!fertilizeMessage.active)
        {
            waterMessage.SetActive(false);
            LeanTween.resume(bar);
            wateringCan.SetActive(true);
            wateringAnim.enabled = true;
            waterEventTime = 0f;
        }
    }

    public void FertilizePlant()
    {
        fertilizeMessage.SetActive(false);
        LeanTween.resume(bar);
        //instantiatedWateringCan = Instantiate(wateringCan, );
    }

    public void InstantiateWorm()
    {
        //Instantiate(worm, flowerPot.transform);
        worm.SetActive(true);
        wormSpawnTime = 0f;
    }
}
