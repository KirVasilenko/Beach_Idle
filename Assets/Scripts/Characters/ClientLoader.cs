using UnityEngine;

public class ClientLoader : MonoBehaviour
{
    private GameObject iconInstance; 
    [SerializeField] private Canvas canvas;

    
    private void Start()
    {
        canvas.enabled = false;
    }
    
    public void ShowIcon(Sprite icon)
    {
        if (icon != null)
        {
            canvas.enabled = true;
            iconInstance = new GameObject("ClientIcon");
            iconInstance.transform.position = transform.position + Vector3.up * 2f;
            iconInstance.AddComponent<SpriteRenderer>().sprite = icon;
        }
    }

    
    public void HideIcon()
    {
       canvas.enabled = false;
    }

    
    public void OnLoaderComplete(Sprite icon)
    {
        ShowIcon(icon); 
    }
}
