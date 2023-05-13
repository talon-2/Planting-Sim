using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuController : MonoBehaviour
{
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

    string corn = "Corn";
    string cucumber = "Cucumber";
    string tomato = "Tomato";
    string turnip = "Turnip";
    string cabbage = "Cabbage";
    string sunflower = "Sunflower";
    string marigold = "Marigold";
    string lavender = "Lavender";
    string coneflower = "Coneflower";
    string cilantro = "Cilantro";
    string thyme = "Thyme";
    string rosemary = "Rosemary";
    string mint = "Mint";

    public static string boughtItem;
    public static bool boughtSmtg = false;
    string boughtPlant;
    string dollarSign = "$";
    InGameUIController gameUIController;

    void Start()
    {
        gameUIController = GetComponent<InGameUIController>();

    }

    void Update()
    {
        boughtItem = boughtPlant;
        cashAmt.text = dollarSign + moneyAmt;
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
        moneyAmt -= 30f;
        boughtPlant = corn;
        boughtSmtg = true;
    }
    public void BoughtCucumber()
    {
        moneyAmt -= 20f;
        boughtPlant = cucumber;
        boughtSmtg = true;
    }
    public void BoughtTomato()
    {
        moneyAmt -= 20f;
        boughtPlant = tomato;
        boughtSmtg = true;
    }
    public void BoughtTurnip()
    {
        moneyAmt -= 10f;
        boughtPlant = turnip;
        boughtSmtg = true;
    }
    public void BoughtCabbage()
    {
        moneyAmt -= 30f;
        boughtPlant = cabbage;
        boughtSmtg = true;
    }
    public void BoughtSunflower()
    {
        moneyAmt -= 10f;
        boughtPlant = sunflower;
        boughtSmtg = true;
    }
    public void BoughtMarigold()
    {
        moneyAmt -= 10f;
        boughtPlant = marigold;
        boughtSmtg = true;
    }
    public void BoughtLavender()
    {
        moneyAmt -= 10f;
        boughtPlant = lavender;
        boughtSmtg = true;
    }
    public void BoughtConeflower()
    {
        moneyAmt -= 10f;
        boughtPlant = coneflower;
        boughtSmtg = true;
    }
    public void BoughtCilantro()
    {
        moneyAmt -= 10f;
        boughtPlant = cilantro;
        boughtSmtg = true;
    }
    public void BoughtThyme()
    {
        moneyAmt -= 10f;
        boughtPlant = rosemary;
        boughtSmtg = true;
    }
    public void BoughtRosemary()
    {
        moneyAmt -= 10f;
        boughtPlant = rosemary;
        boughtSmtg = true;
    }
    public void BoughtMint()
    {
        moneyAmt -= 10f;
        boughtPlant = mint;
        boughtSmtg = true;
    }


}
