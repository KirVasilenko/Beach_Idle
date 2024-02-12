using UnityEngine;
using System.Collections.Generic;

public class FoodManager : MonoBehaviour
{
    public static FoodManager Instance { get; private set; }

    public List<FoodPoint> foodPoints = new List<FoodPoint>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowFoodPoints()
    {
        foreach (var foodPoint in foodPoints)
        {
            foodPoint.gameObject.SetActive(true);
        }
    }

    public void HideFoodPoints()
    {
        foreach (var foodPoint in foodPoints)
        {
            foodPoint.gameObject.SetActive(false);
        }
    }
}
