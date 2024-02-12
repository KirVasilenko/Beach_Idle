using UnityEngine;

public class WaiterLoaderController : MonoBehaviour
{
    public GameObject loaderIcon;

    
    public void SetLoaderPosition(Vector3 position)
    {
        loaderIcon.transform.position = position;
    }

    
    public void ActivateLoader()
    {
        loaderIcon.SetActive(true);
    }

    public void DeactivateLoader()
    {
        loaderIcon.SetActive(false);
    }
}
