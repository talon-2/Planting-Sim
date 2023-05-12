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

    [Header("Animator")]
    public Animator shopAnimator;
    public Animator fertilizeAnimator;
    public Animator waterAnimator;

    public Animator shopMenuAnimator;

    [Header("Panel")]
    public GameObject shopPanel;
    public GameObject inGamePanel;

    bool hideUI = false;
    bool showShop = false;

    public void HideUIBtn()
    {
        if (!hideUI)
        {
            shopAnimator.SetTrigger("HideUI");
            fertilizeAnimator.SetTrigger("HideUI");
            waterAnimator.SetTrigger("HideUI");
            hideUI = true;
        }
        else
        {
            shopAnimator.SetTrigger("ShowUI");
            fertilizeAnimator.SetTrigger("ShowUI");
            waterAnimator.SetTrigger("ShowUI");
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
        if (showShop)
        {
            shopMenuAnimator.SetTrigger("CloseShop");
            inGamePanel.SetActive(true);
            shopPanel.SetActive(false);
        }
        else
        {
            shopMenuAnimator.SetTrigger("OpenShop");
            inGamePanel.SetActive(false);
            shopPanel.SetActive(true);
        }
    }



}
