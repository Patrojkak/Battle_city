using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manazer : MonoBehaviour
{
    public Button onePlayerButton;
    public Button twoPlayersButton;  
    public GameObject tank;

    private RectTransform onePlayerRect;
    private RectTransform twoPlayersRect;

    private Vector3 onePlayerPosition = new Vector3(262, 128, 0);
    private Vector3 twoPlayersPosition = new Vector3(262, 70, 0);

    void Start()
    {
        onePlayerRect = onePlayerButton.GetComponent<RectTransform>();
        twoPlayersRect = twoPlayersButton.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        if (IsPointerOverUI(onePlayerRect, mousePosition))
        {
            tank.transform.position = onePlayerPosition;
        }
        else if (IsPointerOverUI(twoPlayersRect, mousePosition))
        {
            tank.transform.position = twoPlayersPosition;
        }
    }

    private bool IsPointerOverUI(RectTransform rectTransform, Vector3 pointerPosition)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        return pointerPosition.x >= corners[0].x && pointerPosition.x <= corners[2].x &&
               pointerPosition.y >= corners[0].y && pointerPosition.y <= corners[1].y;
    }
}