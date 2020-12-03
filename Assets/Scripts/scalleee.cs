using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalleee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rt = GetComponent<RectTransform>();
        float canvasHeight = rt.rect.height;
        float desiredCanvasWidth = canvasHeight * Camera.main.aspect;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredCanvasWidth);
    }

    void Awake()
    {
        RectTransform rt = GetComponent<RectTransform>();
        float canvasHeight = rt.rect.height;
        float desiredCanvasWidth = canvasHeight * Camera.main.aspect;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredCanvasWidth);
    }
}
