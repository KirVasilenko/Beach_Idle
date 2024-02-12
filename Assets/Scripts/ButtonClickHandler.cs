using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject objectToToggle;
    private Animator objectAnimator;

    private bool isVisible = false;

    void Start()
    {
        objectAnimator = objectToToggle.GetComponent<Animator>();
        objectToToggle.SetActive(false);
    }

    public void ToggleObjectVisibility()
    {
        isVisible = !isVisible;
        objectAnimator.SetBool("isVisible", isVisible);
        objectToToggle.SetActive(isVisible);
    }

    public void HidePopup()
    {
        if (isVisible)
        {
            ToggleObjectVisibility();
        }
    }
}
