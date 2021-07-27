using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    int h, v;

    private void Awake()
    {
        h = Animator.StringToHash("h");
        v = Animator.StringToHash("v");
    }

    public void UpdateAnimatorValues(float hMov, float vMov)
    {
        /*todo: Value snapping
        
        float snappedH, snappedV;
        if(hMov > 0 && hMov < 0.55f)
        {
            snappedH = 0.5f;
        }
        else if(hMov > 0.55f)
        {
            snappedH = 1f;
        }
        if (hMov < 0 && hMov > -0.55f)
        {
            snappedH = -0.5f;   
        }
        else if (hMov < -0.55f)
        {
            snappedH = -1f;
        }
        else snappedH = 0;

        if (vMov > 0 && vMov < 0.55f)
        {
            snappedV = 0.5f;
        }
        else if (vMov > 0.55f)
        {
            snappedV = 1f;
        }
        if (vMov < 0 && vMov > -0.55f)
        {
            snappedV = -0.5f;
        }
        else if (vMov < -0.55f)
        {
            snappedV = -1f;
        }
        else snappedV = 0;
        */

        animator.SetFloat(h, hMov, 0.1f, Time.deltaTime);
        animator.SetFloat(v, vMov, 0.1f, Time.deltaTime);
    }
}
