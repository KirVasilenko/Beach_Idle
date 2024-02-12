using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Food Item")]
public class FoodPointSO : ScriptableObject
{
    public string itemName; // Название продукта
    public int tier; // Тир продукта для дальнейшего использования мультипликатора
    public GameObject itemModelPrefab; // Префаб модели продукта
    public Sprite icon; // Иконка продукта
    public GameObject productPrefab; // Префаб продукта, который официант будет приносить клиенту
}
