using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Vector3 tempGravity;

    public void SwitchGravity()
    {
        Physics.gravity = - Physics.gravity;
    }

    public void OnPrepareAndGameOver()
    {
        tempGravity = Vector3.down * 9.8f;
        Physics.gravity = Vector3.zero;
    }

    public void OnPause()
    {
        tempGravity = Physics.gravity;
        Physics.gravity = Vector3.zero;
    }

    public void OnPlay()
    {
        Physics.gravity = tempGravity;
    }
}
