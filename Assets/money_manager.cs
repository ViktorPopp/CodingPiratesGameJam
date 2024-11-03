using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class money_manager : MonoBehaviour
{
    private float time = 0.0f;
    public float interpolationPeriod = 1f;
    public TMP_Text text;
    [SerializeField] public static float money = 300;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = money.ToString();

        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;

            
            money += 2 * HouseSpawner.connHouses;

        }
    }
}
