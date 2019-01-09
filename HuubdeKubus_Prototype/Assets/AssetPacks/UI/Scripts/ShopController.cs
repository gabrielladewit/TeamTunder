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
    public Text itemNameTxt;

    public GameObject panelBuy;
    public GameObject panelError;
    private Vector3 panelBuyPosition, panelErrorPosition;
    private Vector3 panelInScreenPos;
    private Vector3 panelOutOfScreenPos;
    string theItemName;
    int theItemPrice;


    // Use this for initializatio
    void Start()
    {
        panelInScreenPos = (new Vector3(151.5f, 257.9f, 0.0f));
        panelOutOfScreenPos = new Vector3(151.5f, 795.3f, 0.0f);

        PlayerPrefs.SetInt("Money", 400);
        Destroy(GameObject.Find("UI"));
        inventory = this.gameObject.AddComponent<SaveInventory>();
        currentMoneyText = GameObject.Find("CurrentMoneyText").GetComponent<Text>();
        //livesUpgradeSlider = livesUpgradeObj.GetComponentInChildren<Slider>();
        //StartCoroutine(UpdateShopUI());

        Debug.Log("Panel base position: " + panelBuy.transform.position);
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
                ItemBuyLogic(20, "Sun Ball");

                break;

            case 2:
                ItemBuyLogic(50, "Soccerball");
                break;

            case 3:
                ItemBuyLogic(175, "Basketball");
                break;
            case 4:
                ItemBuyLogic(400, "Earthball");
                break;

            default:
                break;

        }
    }

    private void ItemBuyLogic (int thePrice, string itemName)
    {
        if (thePrice <= PlayerPrefs.GetInt("Money"))
        {
            //int newMoneyVal = PlayerPrefs.GetInt("Money") - thePrice;
            itemNameTxt.text = itemName;
            theItemName = itemName;
            theItemPrice = thePrice;
            panelBuy.transform.position = panelInScreenPos;
            panelError.transform.position = panelOutOfScreenPos;
            //PlayerPrefs.SetInt("Money", newMoneyVal);
            //UpdateShopUI();
        }
        else
        {
            panelBuy.transform.position = panelOutOfScreenPos;
            panelError.transform.position = panelInScreenPos;
            Debug.Log("You dont have enough money");
        }
    }

    public void CheckItemBuyAction(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1:
                int newMoneyVal = PlayerPrefs.GetInt("Money") - theItemPrice;
                PlayerPrefs.SetInt("Money", newMoneyVal);
                UpdateShopUI();
                panelBuy.transform.position = panelOutOfScreenPos;
                panelError.transform.position = panelOutOfScreenPos;
                break;

            case 2:
                panelBuy.transform.position = panelOutOfScreenPos;
                panelError.transform.position = panelOutOfScreenPos;
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
