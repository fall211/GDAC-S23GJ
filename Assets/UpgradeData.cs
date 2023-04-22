using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeType {
    ClickUpgrade,
    AutoClickUpgrade,
    MultiplierUpgrade,
    // Add more types as needed
}

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Upgrade Data")]
public class UpgradeData : ScriptableObject {
    public string upgradeName;
    public UpgradeType upgradeType;
    public int level;
    public double cost;
    public double effectValue;
    public Sprite icon;
    
    public UpgradeData DeepCopy(){
        UpgradeData copy = (UpgradeData)ScriptableObject.CreateInstance(typeof(UpgradeData));
        copy.upgradeName = this.upgradeName;
        copy.upgradeType = this.upgradeType;
        copy.level = this.level;
        copy.cost = this.cost;
        copy.effectValue = this.effectValue;
        copy.icon = this.icon;

        return copy;
    }


}
