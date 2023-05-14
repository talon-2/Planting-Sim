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
    public GameObject CornflowerBtn;

    [Header("Herb Buy Buttons")]
    public GameObject cilantroBtn;
    public GameObject thymeBtn;
    public GameObject rosemaryBtn;
    public GameObject mintBtn;

    [Header("Plants Prefab")]
    public GameObject halfCornPrefab;
    public GameObject fullCornPrefab;
    public GameObject halfCucumberPrefab;
    public GameObject fullCucumberPrefab;
    public GameObject halfTomatoPrefab;
    public GameObject fullTomatoPrefab;
    public GameObject halfTurnipPrefab;
    public GameObject fullTurnipPrefab;
    public GameObject halfCabbagePrefab;
    public GameObject fullCabbagePrefab;
    public GameObject halfSunflowerPrefab;
    public GameObject fullSunflowerPrefab;
    public GameObject halfMarigoldPrefab;
    public GameObject fullMarigoldPrefab;
    public GameObject halfLavenderPrefab;
    public GameObject fullLavanderPrefab;
    public GameObject halfCornflowerPrefab;
    public GameObject fullCornflowerPrefab;
    public GameObject halfCilantroPrefab;
    public GameObject fullCilantroPrefab;
    public GameObject halfThymePrefab;
    public GameObject fullThymePrefab;
    public GameObject halfRosemaryPrefab;
    public GameObject fullRosemaryPrefab;
    public GameObject halfMintPrefab;
    public GameObject fullMintPrefab;

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
    public float cornPrice;
    public float cornProfit;
    public float cucumberPrice;
    public float cucumberProfit;
    public float tomatoPrice;
    public float tomatoProfit;
    public float turnipPrice;
    public float turnipProfit;
    public float cabbagePrice;
    public float cabbageProfit;
    public float sunflowerPrice;
    public float sunflowerProfit;
    public float marigoldPrice;
    public float marigoldProfit;
    public float lavenderPrice;
    public float lavenderProfit;
    public float CornflowerPrice;
    public float CornflowerProfit;
    public float cilantroPrice;
    public float cilantroProfit;
    public float thymePrice;
    public float thymeProfit;
    public float rosemaryPrice;
    public float rosemaryProfit;
    public float mintPrice;
    public float mintProfit;

    [Header("Plant Growth Time")]
    public float cornTime;
    public float cucumberTime;
    public float tomatoTime;
    public float turnipTime;
    public float cabbageTime;
    public float sunflowerTime;
    public float marigoldTime;
    public float lavenderTime;
    public float CornflowerTime;
    public float cilantroTime;
    public float thymeTime;
    public float rosemaryTime;
    public float mintTime;

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
            profit = cornProfit;
            plantGrowthTime = cornTime;
            moneyAmt -= cornPrice;
            instantiatedPlant = Instantiate(halfPlant, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtCucumber()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfCucumberPrefab;
            fullPlant = fullCucumberPrefab;
            profit = cucumberProfit;
            plantGrowthTime = cucumberTime;
            moneyAmt -= cucumberPrice;
            instantiatedPlant = Instantiate(halfCucumberPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtTomato()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfTomatoPrefab;
            fullPlant = fullTomatoPrefab;
            profit = tomatoProfit;
            plantGrowthTime = tomatoTime;
            moneyAmt -= tomatoPrice;
            instantiatedPlant = Instantiate(halfTomatoPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtTurnip()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfTurnipPrefab;
            fullPlant = fullTurnipPrefab;
            profit = turnipProfit;
            plantGrowthTime = turnipTime;
            moneyAmt -= turnipPrice;
            instantiatedPlant = Instantiate(halfTurnipPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtCabbage()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfCabbagePrefab;
            fullPlant = fullCabbagePrefab;
            profit = cabbageProfit;
            plantGrowthTime = cabbageTime;
            moneyAmt -= cabbagePrice;
            instantiatedPlant = Instantiate(halfCabbagePrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtSunflower()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfSunflowerPrefab;
            fullPlant = fullSunflowerPrefab;
            profit = sunflowerProfit;
            plantGrowthTime = sunflowerTime;
            moneyAmt -= sunflowerPrice;
            instantiatedPlant = Instantiate(halfSunflowerPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtMarigold()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfMarigoldPrefab;
            fullPlant = fullMarigoldPrefab;
            profit = marigoldProfit;
            plantGrowthTime = marigoldTime;
            moneyAmt -= marigoldPrice;
            instantiatedPlant = Instantiate(halfMarigoldPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtLavender()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfLavenderPrefab;
            fullPlant = fullLavanderPrefab;
            profit = lavenderProfit;
            plantGrowthTime = lavenderTime;
            moneyAmt -= lavenderPrice;
            instantiatedPlant = Instantiate(halfTomatoPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtCornflower()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfCornflowerPrefab;
            fullPlant = fullCornflowerPrefab;
            profit = CornflowerProfit;
            plantGrowthTime = CornflowerTime;
            moneyAmt -= CornflowerPrice;
            instantiatedPlant = Instantiate(halfCornflowerPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtCilantro()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfCilantroPrefab;
            fullPlant = fullCilantroPrefab;
            profit = cilantroProfit;
            plantGrowthTime = cilantroTime;
            moneyAmt -= cilantroPrice;
            instantiatedPlant = Instantiate(halfCilantroPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtThyme()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfThymePrefab;
            fullPlant = fullThymePrefab;
            profit = thymeProfit;
            plantGrowthTime = thymeTime;
            moneyAmt -= thymePrice;
            instantiatedPlant = Instantiate(halfThymePrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtRosemary()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfRosemaryPrefab;
            fullPlant = fullRosemaryPrefab;
            profit = rosemaryProfit;
            plantGrowthTime = rosemaryTime;
            moneyAmt -= rosemaryPrice;
            instantiatedPlant = Instantiate(halfRosemaryPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
            boughtSmtg = true;
        }
    }
    public void BoughtMint()
    {
        if (plantAmt < plantLimit)
        {
            plantAmt++;
            halfPlant = halfMintPrefab;
            fullPlant = fullMintPrefab;
            profit = mintProfit;
            plantGrowthTime = mintTime;
            moneyAmt -= rosemaryPrice;
            instantiatedPlant = Instantiate(halfRosemaryPrefab, flowerPot.transform);
            AnimateBar(plantGrowthTime);
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
