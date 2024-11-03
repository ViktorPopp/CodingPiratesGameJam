using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold;
    public TMPro.TMP_Text goldText;
    public CustomCursor cursor;
    public GameObject grid;

    [SerializeField] private Tower towerToPlace;

    void Update()
    {
        goldText.text = "Gold: " + gold.ToString();
    }

    public void BuyTower(Tower tower)
    {
        if (gold >= tower.cost)
        {
            cursor.gameObject.SetActive(true);
            cursor.GetComponent<MeshFilter>().mesh = tower.GetComponent<MeshFilter>().mesh;
            Cursor.visible = false;

            gold -= tower.cost;
            towerToPlace = tower;
            grid.SetActive(true);
        }
    }
}
