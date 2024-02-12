using UnityEngine;

public class TouchInputController : MonoBehaviour
{
    public bool IsPressed()
    {
#if UNITY_EDITOR
        return Input.GetMouseButtonDown(0);
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.phase == TouchPhase.Began;
        }
        return false;
#else
        return false;
#endif
    }

    public Vector3 GetTouchPosition()
    {
#if UNITY_EDITOR
        return Input.mousePosition;
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            return touch.position;
        }
        return Vector3.zero;
#else
        return Vector3.zero;
#endif
    }
}
