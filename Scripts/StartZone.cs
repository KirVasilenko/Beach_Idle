using UnityEngine;

public class StartZone : MonoBehaviour
{
    public GameObject startZone;
    public GameObject splashEffect;
    public GameObject gameItem;

    private TouchInputController _touch;

    private void Start()
    {
        if (startZone != null)
            startZone.SetActive(true);

        if (splashEffect != null)
            splashEffect.SetActive(false);

        if (gameItem != null)
            gameItem.SetActive(false);

        _touch = GetComponent<TouchInputController>();
    }

    private void Update()
    {
        if (_touch == null)
        {
            Debug.LogError("TouchInputController not found");
            return;
        }

        if (_touch.IsPressed())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(_touch.GetTouchPosition());

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == startZone)
            {
                startZone.SetActive(false);
                splashEffect.SetActive(true);

                Invoke("ActivateGameItem", 1f);
            }
        }
    }

    private void ActivateGameItem()
    {
        splashEffect.SetActive(false);

        if (gameItem != null)
            gameItem.SetActive(true);
    }
}
