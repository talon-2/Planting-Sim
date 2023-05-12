using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject hideUIButton;
    public GameObject fertilizeButton;
    public GameObject waterButton;
    public GameObject shopButton;

    public Animation hideShopAnim;
    public Animation hideFertilizeAnim;
    public Animation hideWaterAnim;

    bool hideUI = false;

    public void HideUIBtn()
    {
        if (!hideUI)
        {
            hideWaterAnim.Play("HideWaterAnim");
            hideShopAnim.Play("HideShopAnim");
            hideFertilizeAnim.Play("HideFertilizeAnim");

            hideUI = true;
        }
        else
        {
            hideUI = false;
        }
    }
    public void FertilizeBtn()
    {

    }
    public void WaterBtn()
    {

    }
    public void ShopBtn()
    {

    }

}
