using UnityEngine;

public class FoodPoint : MonoBehaviour
{
     public Sprite foodSprite;
    
    private bool isOccupied = false;

    public void SendFoodSpriteToClient(ClientLoader clientLoader)
    {
        clientLoader.ShowIcon(foodSprite);
    }

    private void Start()
    {
        
        isOccupied = false;
    }

    
    public bool IsOccupied()
    {
        return isOccupied;
    }

   
    public void SetOccupied(bool occupied)
    {
        isOccupied = occupied;
    }
}
