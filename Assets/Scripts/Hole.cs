using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameObject holeTrigger;

    public void On()
    {
        holeTrigger.SetActive(true);
    }

    public void Off()
    {
        holeTrigger.SetActive(false);
    }
}
