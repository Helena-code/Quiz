using UnityEngine;
using UnityEngine.Events;

public class TouchScript : MonoBehaviour
{
    public UnityEvent TouchEvent;

    
    public void OnMouseDown()
    {
        TouchEvent.Invoke();
    }
}
