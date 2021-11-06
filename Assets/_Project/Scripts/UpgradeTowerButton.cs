using UnityEngine;

public class UpgradeTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Tower tower = gameObject.transform.parent.GetComponent<Tower>();
        int upgradeCost = tower.getTowerCost() * (tower.towerLevel + 1);

        if (tower.towerLevel -1 <= tower.sprites.Length && GameManager.instance.getCoins() >= upgradeCost)
        {
            GameManager.instance.setCoins(GameManager.instance.getCoins() - upgradeCost);
            tower.Upgrade();
        }
    }
}