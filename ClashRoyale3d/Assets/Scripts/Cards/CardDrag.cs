using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Realtime;
using Photon.Pun;

public class CardDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 lastMousePosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastMousePosition = eventData.position;
        gameObject.transform.SetParent(GameObject.Find("Panels").transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = GetComponent<RectTransform>();

        Vector3 newPosition = rect.position + new Vector3(diff.x, diff.y, transform.position.z);
        Vector3 oldPos = rect.position;
        rect.position = newPosition;

        if (!IsRectTransformInsideSreen(rect))
        {
            rect.position = oldPos;
        }
        lastMousePosition = currentMousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gameObject.transform.SetParent(GameObject.Find("CardsPanel").transform);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name.Contains("grid"))
            {
                GetComponent<PhotonView>().RPC("InstantiatePrefab", RpcTarget.All, hit.collider.gameObject.transform.position);
            }
        }
    }

    private bool IsRectTransformInsideSreen(RectTransform rectTransform)
    {
        bool isInside = false;
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        int visibleCorners = 0;
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        foreach (Vector3 corner in corners)
        {
            if (rect.Contains(corner))
            {
                visibleCorners++;
            }
        }
        if (visibleCorners == 4)
        {
            isInside = true;
        }
        return isInside;
    }

    [PunRPC]
    private void InstantiatePrefab(Vector3 pos)
    {
        GameObject obj = Instantiate(GetComponent<Card>().characterPrefab);
        obj.transform.SetParent(null);
        obj.transform.position = -(pos);
        
    }
   
}
