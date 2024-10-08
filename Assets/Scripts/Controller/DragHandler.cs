using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [HideInInspector]
    public Transform parentAfterDrag;
    private Image imgItem;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        transform.SetParent(transform.root);
        //transform.SetAsLastSibling();
        imgItem.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        imgItem.raycastTarget = true;
        Debug.Log("End");
    }

    // Start is called before the first frame update
    void Start()
    {
        imgItem = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
