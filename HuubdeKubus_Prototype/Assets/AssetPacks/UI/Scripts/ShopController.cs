using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{

    public GameObject livesUpgradeObj, heavyBallObj;
    private Text currentMoneyText;
    private Slider livesUpgradeSlider;
    public SaveInventory inventory;
    public Text currentMoneyTxt;

    // Use this for initializatio
    void Start()
    {
        PlayerPrefs.SetInt("Money", 400);
        Destroy(GameObject.Find("UI"));
        //inventory = this.gameObject.AddComponent<SaveInventory>();
        currentMoneyText = GameObject.Find("CurrentMoneyText").GetComponent<Text>();
        //livesUpgradeSlider = livesUpgradeObj.GetComponentInChildren<Slider>();
        //StartCoroutine(UpdateShopUI());

        Debug.Log("Hoi");
        currentMoneyText.text = "" + PlayerPrefs.GetInt("Money");
    }

    public void Update()
    {
        if (inventory.initialized)
        {
            LoadShopInventory();
        }
    }

    public void LoadShopInventory()
    {
        
    }

    public void BuyItem(int buttonNumber)
    {
        switch(buttonNumber){
            case 1:
                if (20 <= PlayerPrefs.GetInt("Money"))
                {
                    int newMoneyVal = PlayerPrefs.GetInt("Money") - 20;
                    PlayerPrefs.SetInt("Money", newMoneyVal);
                    UpdateShopUI();
                }
                else
                {
                    Debug.Log("You dont have enough money");
                }
                break;

            case 2:
                if (50 <= PlayerPrefs.GetInt("Money"))
                {
                    int newMoneyVal = PlayerPrefs.GetInt("Money") - 50;
                    PlayerPrefs.SetInt("Money", newMoneyVal);
                    UpdateShopUI();
                }
                else
                {
                    Debug.Log("You dont have enough money");
                }
                break;

            case 3:
                if (175 <= PlayerPrefs.GetInt("Money"))
                {
                    int newMoneyVal = PlayerPrefs.GetInt("Money") - 175;
                    PlayerPrefs.SetInt("Money", newMoneyVal);
                    UpdateShopUI();
                }
                else
                {
                    Debug.Log("You dont have enough money");
                }
                break;
            case 4:
                if (400 <= PlayerPrefs.GetInt("Money"))
                {
                    int newMoneyVal = PlayerPrefs.GetInt("Money") - 400;
                    PlayerPrefs.SetInt("Money", newMoneyVal);
                    UpdateShopUI();
                }
                else
                {
                    Debug.Log("You dont have enough money");
                }
                break;

            default:
                break;

        }
    }

    public void BuyLivesUpgrade()
    {
        switch (inventory.currentLives)
        {
            case 0:
                if (inventory.currentMoney >= 100)
                {
                    inventory.SpendMoney(100);
                    inventory.AddLife();
                    livesUpgradeSlider.value++;
                }
                return;
            case 1:
                if (inventory.currentMoney >= 200)
                {
                    inventory.SpendMoney(200);
                    inventory.AddLife();
                    livesUpgradeSlider.value++;
                }
                return;
            case 2:
                if (inventory.currentMoney >= 400)
                {
                    inventory.SpendMoney(400);
                    inventory.AddLife();
                    livesUpgradeObj.GetComponentInChildren<Button>().interactable = false;
                }
                return;
        }
    }

    public void BuyHeavyBall()
    {   // PlayerMoney >= Price
        if (inventory.currentMoney >= 250)
        {
            inventory.SpendMoney(400);
            inventory.SetBoughtHeavy();
            heavyBallObj.GetComponentInChildren<Button>().interactable = false;
        }
    }

    void UpdateShopUI()
    {
            currentMoneyText.text = PlayerPrefs.GetInt("Money").ToString();

    }
}
