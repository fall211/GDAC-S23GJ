using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public UpgradeData upgradeData;
    public TextMeshPro upgradeNameText;
    public TextMeshPro upgradeLevelText;
    public TextMeshPro upgradeCostText;
    public SpriteRenderer upgradeIcon;

    private void Start() {
        UpdateUI();
    }

    public void UpdateUI() {
        upgradeNameText.text = upgradeData.upgradeName;
        upgradeCostText.text = "Cost: " + (int)upgradeData.cost;
        upgradeLevelText.text = "Level: " + upgradeData.level;
        upgradeIcon.sprite = upgradeData.icon;
    }

    public void BuyUpgrade() {

        if (UpgradeManager.Instance.CanPurchaseUpgrade(upgradeData))
        {
            UpgradeManager.Instance.PurchaseUpgrade(upgradeData);
            UpdateUI();
        }
    }

}
