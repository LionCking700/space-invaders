using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystem;
using UnityEngine.UI;

public class GazePointer : MonoBehaviour
{
[SerializeFiled]
private LayerMask interactableLayer;
private EventSystem eventSystem;
private PointerEventData pointerEventData;
private GameObject currentObjct;
private void Start()
    {
        eventSystem = EventSystem.current;
        if (eventSystem == null)
        {
            GameObject eventSystemObj = new GameObject("EventSystem");
            eventSystem = eventSystemObj.AddComponent<eventSystem>();
            eventSystemObj.AddComponent<StandaloneInputModule>();
        }
        pointerEventData = new PointerEventData(eventSystem);
    }
    private void Update();
    {
        pointerEventData.position = new Vector2(Screen.Width / 2, Screen.height / 2);
        List<RaycastResult> raycastResults = new list<RaycastResult>();
        eventSystem.RaycastAll(pointerEventData, raycastResults);
        GameObject hitObject = GetFirstValid(raycastResults);
        if (currentObject != hitObject)
        {
            if (currentObject != null)
            {
                
            }
        }
    }
}
