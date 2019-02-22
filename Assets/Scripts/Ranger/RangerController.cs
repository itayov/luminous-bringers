﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerController : PlayerController
{
    // Public ElementalBall Members
    public GameObject arrowToRight, arrowToLeft;

    // Private ElementalBall Members
    private float arrowWaitTime;
    private float xArrowPosition = 0.7f;

    private bool isArrowInAir = false;

    // --------
    // Starters
    // --------
    new void Start()
    {
        base.Start();

        arrowWaitTime = base.leftClickAnimTime - 0.33f;
    }
    
    // -----------
    // Controllers
    // -----------
    protected override void LeftClick()
    {
        Cast(arrowToRight, arrowToLeft, arrowWaitTime);
    }

    protected override void RightClick()
    {
        Cast(arrowToRight, arrowToLeft, arrowWaitTime);
    }
    
    void Cast(GameObject elementalToRight, GameObject elementalToLeft, float waitTime)
    {
        // Coroutine of casting to wait a little before creating the elemental ball (so the animation would get to the right frame)
        if (base.isFacingRight)
        {
            StartCoroutine(OnCast(elementalToRight, xArrowPosition, waitTime));
        }
        else
        {
            StartCoroutine(OnCast(elementalToLeft, (-1) * xArrowPosition, waitTime));
        }
    }

    // ------
    // Events
    // ------
    IEnumerator OnCast(GameObject elemental, float x_position, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Vector2 elementalPosition = transform.position;

        elementalPosition += new Vector2(x_position, 0f);
        Instantiate(elemental, elementalPosition, Quaternion.identity);
    }
}
