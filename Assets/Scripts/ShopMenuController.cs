using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    int plantAmt;
    //public static string boughtItem;
    public static bool boughtSmtg = false;
    string boughtPlant;
    string dollarSign = "$";
    InGameUIController gameUIController;
    GameObject flowerPot;
    string pot = "FlowerPot";
    GameObject instantiatedPlant;
    

    void Start()
    {
        gameUIController = GetComponent<InGameUIController>();
        flowerPot = GameObject.FindGameObjectWithTag(pot);
    }

    void Update()
    {
        cashAmt.text = dollarSign + moneyAmt;
        Debug.Log(boughtSmtg + ", " + plantAmt) ;
        if(boughtSmtg && plantAmt <= plantLimit)
        {
            instantiatedPlant.transform.localPosition = new Vector3(0f, 0.85f, -0.1f);
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
            moneyAmt -= 30f;
            instantiatedPlant = Instantiate(halfCornPrefab, flowerPot.transform);
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

}
