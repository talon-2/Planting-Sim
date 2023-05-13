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

    [Header("Main Menu Animator")]
    public Animator startGameAnimator;
    public Animator quitGameAnimator;
    public Animator openInstructionsAnimator;
    public Animator closeInstructionAnimator;

    [Header("Settings Animator")]
    public Animator settingsAnimator;
    public Animator continueGameAnimator;
    public Animator settingsQuitGameAnimator;


    [Header("Panel")]
    public GameObject shopPanel;
    public GameObject inGamePanel;
    public GameObject instructionPanel;
    public GameObject mainMenuPanel;
    public GameObject moneyPanel;
    public GameObject settingsPanel;

    bool hideUI = false;
    bool fertilizing = false;
    bool watering = false;

    void Update()
    {
        if (ShopMenuController.boughtSmtg)
        {
            CloseShopBtn();
            ShopMenuController.boughtSmtg = false;
            //check for item = shopMenuController.boughtItem;
            //then when tap on a pot, plant it.
            //set boughtSmtg back to false after plant;
        }
        if (fertilizing)
        {
            //if click a plant, fertilize and speed up timer
            //if click anywhere else, cancel
            fertilizing = false;
        }
        if (watering)
        {
            //same with fertilizing
            watering = false;
        }
        if (startGameAnimator.enabled)
        {
            if (startGameAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                mainMenuPanel.SetActive(false);
                inGamePanel.SetActive(true);
                shopPanel.SetActive(true);
                moneyPanel.SetActive(true);
                startGameAnimator.enabled = false;
            }
        }
        else if (quitGameAnimator.enabled || settingsQuitGameAnimator.enabled)
        {
            if (quitGameAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                Application.Quit();
            }
        }
        else if (openInstructionsAnimator.enabled)
        {
            if (openInstructionsAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                instructionPanel.SetActive(true);
                mainMenuPanel.SetActive(false);
                openInstructionsAnimator.enabled = false;
            }
        }
        else if (closeInstructionAnimator.enabled)
        {
            if (closeInstructionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                instructionPanel.SetActive(false);
                mainMenuPanel.SetActive(true);
                closeInstructionAnimator.enabled = false;
            }
        }
        else if (continueGameAnimator.enabled)
        {
            if (continueGameAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                settingsAnimator.SetTrigger("CloseSettings");
                if (settingsAnimator.GetCurrentAnimatorStateInfo(1).normalizedTime > 1.0f)
                {
                    settingsPanel.SetActive(false);
                }
                continueGameAnimator.enabled = false;
            }
        }
    }

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
        fertilizing = true;
    }
    public void WaterBtn()
    {
        watering = true;
    }
    public void OpenShopBtn()
    {
        shopMenuAnimator.SetTrigger("OpenShop");
        inGamePanel.SetActive(false);
    }
    public void CloseShopBtn()
    {
        shopMenuAnimator.SetTrigger("CloseShop");
        inGamePanel.SetActive(true);
    }

    public void StartGame()
    {
        startGameAnimator.enabled = true;
    }
    public void CloseGame()
    {
        quitGameAnimator.enabled = true;
    }
    public void OpenInstructions()
    {
        openInstructionsAnimator.enabled = true;
    }

    public void CloseInstructions()
    {
        closeInstructionAnimator.enabled = true;
    }

    public void OpenSettingsBtn()
    {
        settingsPanel.SetActive(true);
        settingsAnimator.SetTrigger("OpenSettings");
    }

    public void ContinueGameBtn()
    {
        continueGameAnimator.enabled = true;
    }
    
    public void SettingsQuitGameBtn()
    {
        settingsQuitGameAnimator.enabled = true;
    }
}