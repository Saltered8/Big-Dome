﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAim : MonoBehaviour
{
    public float speed = 1;
    LayerMask m_LayerMask;
    private void Awake()
    {
        m_LayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame     
    private void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_LayerMask)) 
        //{ 
        //    transform.LookAt(hit.point);

        //    transform.eulerAngles = transform.eulerAngles.y * Vector3.up;
        //}


        transform.eulerAngles += Vector3.up * Input.GetAxis("Mouse X")*speed * Time.deltaTime;
    }
}
