using System.Collections;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        canvas.enabled = false;
    }

    public void ShowLoader()
    {
        canvas.enabled = true;
        animator.SetTrigger("ShowLoaderTrigger");
        StartCoroutine(HideLoaderAfterDelay());
    }

    private IEnumerator HideLoaderAfterDelay()
    {
        yield return new WaitForSeconds(1f); 
        animator.ResetTrigger("ShowLoaderTrigger"); 
        HideLoader(); 
    }

    public void HideLoader()
    {
        canvas.enabled = false;
    }
}
