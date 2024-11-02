using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        this.gameObject.GetComponentInChildren<HouseSpawner>(true).SpawnHouse();
    }
}
