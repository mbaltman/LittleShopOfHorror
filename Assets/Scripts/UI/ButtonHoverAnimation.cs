using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverAnimation : MonoBehaviour
{
    public string animationOnEnter;
    public string animationOnLeave;

    void OnMouseEnter()
    {
        GetComponent<Animator>().Play(animationOnEnter);
    }

    void OnMouseExit()
    {
        GetComponent<Animator>().Play(animationOnLeave);
    }
}