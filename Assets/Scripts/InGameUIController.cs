using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    [Header("Checking booleans")]
    public bool qrCodeScanned = false;

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
    public Animator warningScanPotAnimator;
    public Animator waterCanAnimator;

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
    public GameObject scanPotNotiPanel;

    [Header("Watering Can")]
    public GameObject wateringCan;

    bool hideUI = false;
    bool fertilizing = false;
    public static bool potUsed = false;
    bool watering = false;


    void Update()
    {
        if (ShopMenuController.boughtSmtg && !potUsed)
        {
            CloseShopBtn();
            potUsed = true;
        }
        if (fertilizing)
        {
            fertilizing = false;
        }
        if (watering)
        {
            if (waterCanAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
              waterCanAnimator.enabled = false;
                wateringCan.transform.localScale = new Vector3(0f, 0f, 0f);
               wateringCan.SetActive(false);
                watering = false;
            }
        }


        //animators
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
        else if(warningScanPotAnimator.enabled)
        {
            if(warningScanPotAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                scanPotNotiPanel.SetActive(false);
                warningScanPotAnimator.enabled = false;
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
        wateringCan.SetActive(true);
        waterCanAnimator.enabled = true;
        watering = true;
    }
    public void OpenShopBtn()
    {
        if (qrCodeScanned)
        {
            shopMenuAnimator.SetTrigger("OpenShop");
            inGamePanel.SetActive(false);
        }
        else
        {
            scanPotNotiPanel.SetActive(true);
            warningScanPotAnimator.enabled = true;
        }

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

    public void QRCodeScanned()
    {
        qrCodeScanned = true;
    }
}