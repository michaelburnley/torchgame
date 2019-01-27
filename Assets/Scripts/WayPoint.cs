using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public GameObject wayPoint;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        transform.SetParent(canvas.transform);
    }

    // Update is called once per frame
    void Update()
    {

        RectTransform navPoint = wayPoint.GetComponent<RectTransform>();
        RectTransform CanvasRect = canvas.GetComponent<RectTransform>();

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        screenPoint.x = Mathf.Clamp(screenPoint.x, 100f, 924f);
        screenPoint.y = Mathf.Clamp(screenPoint.y, 100f, 782f);

        navPoint.anchoredPosition = screenPoint - CanvasRect.sizeDelta;
    }
}
