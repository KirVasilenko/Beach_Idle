using UnityEngine;

public class FoodPointInstance : MonoBehaviour
{
    public FoodPointSO foodItem; // Ссылка на скриптовый объект с информацией о продукте
    public GameObject boxPrefab; // Префаб ящика, на который нужно нажать игроку
    public GameObject splashPrefab; // Префаб анимации splash

    private void Start()
    {
        HideObject(boxPrefab);
        HideObject(splashPrefab);
    }

    // Метод для скрытия объекта
    private void HideObject(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(false);
        }
    }

    // Метод для показа объекта
    private void ShowObject(GameObject obj)
    {
        if (obj != null)
        {
            obj.SetActive(true);
        }
    }

    // Метод для появления точки с едой
    public void Appear()
    {
        // Показываем ящик
        ShowObject(boxPrefab);
    }

    // Метод для показа анимации splash
    public void ShowSplash()
    {
        // Показываем анимацию splash
        ShowObject(splashPrefab);

        // Вызываем метод для создания точки еды через некоторое время
        Invoke("CreateFoodPoint", 0.5f);
    }

    // Метод для создания точки еды
    private void CreateFoodPoint()
    {
        Instantiate(foodItem.itemModelPrefab, transform.position, Quaternion.identity);
    }
}
