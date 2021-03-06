﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountQuads : MonoBehaviour
{
    public static int QuadCount;
    public static int CloseQuads;
    public static Camera MainCamera;
    public static Plane[] Planes;
    [SerializeField] private Text text;
    void Start()
    {
        QuadCount = 0;
    }

    private static float movementSpeed = .5f;
    void Update()
    {
        MainCamera = GetComponent<Camera>();
        text.text = "Quad Count: " + QuadCount + "   &&&&   CloseQuads: " + CloseQuads;
        Planes = GeometryUtility.CalculateFrustumPlanes(MainCamera);
        movementSpeed = Mathf.Max(movementSpeed += Input.GetAxis("Mouse ScrollWheel"), 0.0f);
        transform.position += (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")) * movementSpeed;
        transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);

        CloseQuads = 0;
    }
}
