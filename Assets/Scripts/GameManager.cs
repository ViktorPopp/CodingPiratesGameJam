using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold;
    public TMPro.TMP_Text goldText;
    [SerializeField] Tower towerToPlace;
    public GameObject grid;

    void Update()
    {
        goldText.text = "Gold: " + gold.ToString();
    }

    public void BuyTower(Tower type)
    {
        if (gold >= type.cost)
        {
            gold -= type.cost;
            towerToPlace = type;
            grid.SetActive(true);
        }
    }
}
