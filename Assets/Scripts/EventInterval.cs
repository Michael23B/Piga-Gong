using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// Calls a UnityEvent set from the inspector at a set interval.
public class EventInterval : MonoBehaviour
{
    public float intervalTime = 3f;
    public UnityEvent unityEvent;
    private Coroutine coroutine; 

    private void Start()
    {
        coroutine = StartCoroutine(CallEvent());
    }

    private IEnumerator CallEvent()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            unityEvent?.Invoke();
        }
    }

    private void OnDestroy()
    {
        StopCoroutine(coroutine);
    }
}
