using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingNibba : MonoBehaviour
{
    public Animator m_Animator;
    private bool isSwinging = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSwinging = !isSwinging;
           
        }
        m_Animator.SetBool("swing",isSwinging);
    }
}
