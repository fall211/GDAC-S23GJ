using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public PeachesTxtUpdate peachesTxtUpdate;
    public List<UpgradeData> upgradeDataList;
    private List<UpgradeData> runtimeUpgradeData;

    public GameObject upgradePrefab;
    public Transform upgradesParent;
    public double totalPeaches;

    public double clickAmount = 1;
    public double autoClickAmount = 0;
    public double multiplierAmount = 1;

    public NewsTicker newsScript;

    public static UpgradeManager Instance { get; private set; }

    private void Awake(){

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start() {

        runtimeUpgradeData = new List<UpgradeData>();
        foreach (UpgradeData upgrade in upgradeDataList) {
            runtimeUpgradeData.Add(upgrade.DeepCopy());
        }

        LoadUpgrades();
        applyEffects();
    }

    private void resetStats() {
        clickAmount = 1;
        autoClickAmount = 0;
        multiplierAmount = 1;
    }

    // load upgrades from resources or other sources
    public void LoadUpgrades() {
        foreach (UpgradeData data in runtimeUpgradeData)
        {
            // Instantiate the prefab and set its parent
            GameObject upgradeObject = Instantiate(upgradePrefab, upgradesParent);

            // Get the UpgradeUI component and set the upgradeData
            ImprovedUpgradeUI upgradeUI = upgradeObject.GetComponent<ImprovedUpgradeUI>();
            upgradeUI.upgradeData = data;

            

        }
        upgradesParent.GetComponent<ResizeContentField>().Resize();
    }

    public bool CanPurchaseUpgrade(UpgradeData upgradeData) {
        return totalPeaches >= upgradeData.cost;
    }

    public void PurchaseUpgrade(UpgradeData upgradeData) {
        if (CanPurchaseUpgrade(upgradeData))
        {
            totalPeaches -= upgradeData.cost;
            upgradeData.level++;
            upgradeData.cost *= 1.5;
            applyEffects();
        }
    }

    public void applyEffects() {
        clickAmount = 1;
        autoClickAmount = 0;
        multiplierAmount = 1;
        foreach (UpgradeData data in runtimeUpgradeData) {
            if (data.level > 0) {
                switch (data.upgradeType) {
                    case UpgradeType.ClickUpgrade:
                        clickAmount += data.effectValue * data.level;
                        break;
                    case UpgradeType.AutoClickUpgrade:
                        autoClickAmount += data.effectValue * data.level;
                        break;
                    case UpgradeType.MultiplierUpgrade:
                        multiplierAmount += data.effectValue * data.level;
                        break;
                }
            }
        }
        Debug.Log("Click Amount: " + clickAmount);
        Debug.Log("Auto Click Amount: " + autoClickAmount);
        Debug.Log("Multiplier Amount: " + multiplierAmount);
    }

    private void Update() {
        addPeaches(autoClickAmount * multiplierAmount * Time.deltaTime);
    }


    public void addPeaches(double amount) {
        totalPeaches += amount;
        peachesTxtUpdate.updateCount((int)totalPeaches);
        newsScript.totalPeaches = (int)totalPeaches;
    }

    public double getPeachesCount() {
        return totalPeaches;
    }

    public void removePeaches(double amount) {
        totalPeaches -= amount;
        peachesTxtUpdate.updateCount((int)totalPeaches);
    }

    public void setPeaches(double amount) {
        totalPeaches = amount;
        peachesTxtUpdate.updateCount((int)totalPeaches);
    }



}
