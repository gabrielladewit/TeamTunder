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

    // Use this for initializatio
    void Start()
    {
        Destroy(GameObject.Find("UI"));
        inventory = this.gameObject.AddComponent<SaveInventory>();
        currentMoneyText = GameObject.Find("CurrentMoneyText").GetComponent<Text>();
        livesUpgradeSlider = livesUpgradeObj.GetComponentInChildren<Slider>();
        StartCoroutine(UpdateShopUI());
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

    public void BuyLivesUpgrade()
    {
        switch (inventory.currentLives)
        {
            case 0:
                if (inventory.currentCoins >= 100)
                {
                    inventory.SpendCoins(100);
                    inventory.AddLife();
                    livesUpgradeSlider.value++;
                }
                return;
            case 1:
                if (inventory.currentCoins >= 200)
                {
                    inventory.SpendCoins(200);
                    inventory.AddLife();
                    livesUpgradeSlider.value++;
                }
                return;
            case 2:
                if (inventory.currentCoins >= 400)
                {
                    inventory.SpendCoins(400);
                    inventory.AddLife();
                    livesUpgradeObj.GetComponentInChildren<Button>().interactable = false;
                }
                return;
        }
    }

    public void BuyHeavyBall()
    {   // PlayerMoney >= Price
        if (inventory.currentCoins >= 250)
        {
            inventory.SpendCoins(400);
            inventory.SetBoughtHeavy();
            heavyBallObj.GetComponentInChildren<Button>().interactable = false;
        }
    }

    IEnumerator UpdateShopUI()
    {
        while (true)
        {
            currentMoneyText.text = inventory.GetCurrentMoney().ToString();
            livesUpgradeSlider.value = inventory.GetCurrentLives();
            heavyBallObj.GetComponentInChildren<Button>().enabled = !inventory.GetCurrentBoughtHeavy();
            yield return new WaitForSeconds(1);
        }
    }
}
