using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelScript : MonoBehaviour
{
    public Sprite upgradeActiveImage;
    public Sprite upgradeNotActiveImage;

 // ---  missile speed GUI items
    public TMPro.TextMeshProUGUI missileSpeedUpgradePriceInfoText;
    public Image[] missileSpeedUpgradeLevels;

 // ---  explosion range GUI items
    public TMPro.TextMeshProUGUI explosionRangeUpgradePriceInfoText;
    public Image[] explosionRangeUpgradeLevels;

 // ---  missile cooldown GUI items
    public TMPro.TextMeshProUGUI missileCooldownUpgradePriceInfoText;
    public Image[] missileCooldownUpgradeLevels;

 // ---  movement speed GUI items
    public TMPro.TextMeshProUGUI movementSpeedUpgradePriceInfoText;
    public Image[] movementSpeedUpgradeLevels;



    // Update is called once per frame
    void Update()
    {
        if(Singleton.Instance.missileSpeedCurrentLevel < 4)
            missileSpeedUpgradePriceInfoText.text = "Upgrade for " +
                Singleton.Instance.missileSpeedUpgradePrices[Singleton.Instance.missileSpeedCurrentLevel].ToString() +
                " points";
        else
            missileSpeedUpgradePriceInfoText.text = "Fully upgraded!";


        if(Singleton.Instance.explosionRangeCurrentLevel < 4)
            explosionRangeUpgradePriceInfoText.text = "Upgrade for " +
                Singleton.Instance.explosionRangeUpgradePrices[Singleton.Instance.explosionRangeCurrentLevel].ToString() +
                " points";
        else
            explosionRangeUpgradePriceInfoText.text = "Fully upgraded!";


        if(Singleton.Instance.missileCooldownCurrentLevel < 4)
            missileCooldownUpgradePriceInfoText.text = "Upgrade for " +
                Singleton.Instance.missileCooldownUpgradePrices[Singleton.Instance.missileCooldownCurrentLevel].ToString() +
                " points";
        else
            missileCooldownUpgradePriceInfoText.text = "Fully upgraded!";


        if(Singleton.Instance.movementSpeedCurrentLevel < 2)
            movementSpeedUpgradePriceInfoText.text = "Upgrade for " +
                Singleton.Instance.movementSpeedUpgradePrices[Singleton.Instance.movementSpeedCurrentLevel].ToString() +
                " points";
        else
            movementSpeedUpgradePriceInfoText.text = "Fully upgraded!";
    }       

    public void UpgradeMissileSpeedClick()
    {
        if(Singleton.Instance.missileSpeedCurrentLevel >= 4)
            return;

        if(Singleton.Instance.points >= Singleton.Instance.missileSpeedUpgradePrices[Singleton.Instance.missileSpeedCurrentLevel])
        {
            Singleton.Instance.UpgradeMissileSpeed();
            missileSpeedUpgradeLevels[Singleton.Instance.missileSpeedCurrentLevel].sprite = upgradeActiveImage;
        }
    }

    public void UpgradeExplosionRangeClick()
    {
        if(Singleton.Instance.explosionRangeCurrentLevel >= 4)
            return;

        if(Singleton.Instance.points >= Singleton.Instance.explosionRangeUpgradePrices[Singleton.Instance.explosionRangeCurrentLevel])
        {
            Singleton.Instance.UpgradeExplosionRange();
            explosionRangeUpgradeLevels[Singleton.Instance.explosionRangeCurrentLevel].sprite = upgradeActiveImage;
        }
    }

    public void UpgradeMissileCooldownClick()
    {
        if(Singleton.Instance.missileCooldownCurrentLevel >= 4)
            return;

        if(Singleton.Instance.points >= Singleton.Instance.missileCooldownUpgradePrices[Singleton.Instance.missileCooldownCurrentLevel])
        {
            Singleton.Instance.UpgradeMissileCooldown();
            missileCooldownUpgradeLevels[Singleton.Instance.missileCooldownCurrentLevel].sprite = upgradeActiveImage;
        }
    }

    public void UpgradeMovementSpeedClick()
    {
        if(Singleton.Instance.movementSpeedCurrentLevel >= 2)
            return;

        if(Singleton.Instance.points >= Singleton.Instance.movementSpeedUpgradePrices[Singleton.Instance.movementSpeedCurrentLevel])
        {
            Singleton.Instance.UpgradeMovementSpeed();
            movementSpeedUpgradeLevels[Singleton.Instance.movementSpeedCurrentLevel].sprite = upgradeActiveImage;
        }
    }
}
