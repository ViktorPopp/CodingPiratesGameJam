using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gold;
    public TMPro.TMP_Text goldText;
    public CustomCursor cursor;
    public GameObject grid;
    public Tile[] tiles;
    

    [SerializeField] private Tower towerToPlace;

    void Update()
    {
        goldText.text = "Gold: " + gold.ToString();

        if (Input.GetMouseButtonDown(0) && towerToPlace != null)
        {
            Tile nearestTile = null;
            float shortestDistance = float.MaxValue;

            foreach (Tile tile in tiles)
            {
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestTile = tile;
                }
            }

            if (nearestTile.isOccupied != true)
            {
                Instantiate(towerToPlace, nearestTile.transform.position, Quaternion.identity);
                towerToPlace = null;
                nearestTile.isOccupied = true;
                grid.SetActive(false);
                cursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    public void BuyTower(Tower tower)
    {
        if (gold >= tower.cost)
        {
            cursor.gameObject.SetActive(true);
            cursor.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;

            gold -= tower.cost;
            towerToPlace = tower;
            grid.SetActive(true);
        }
    }
}
