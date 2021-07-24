using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPrepare : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private GameObject finger;

    public void OnGamePlay()
    {
        buttonPlay.gameObject.SetActive(false);
        finger.SetActive(false);
    }

    public void OnPrepare()
    {
        buttonPlay.gameObject.SetActive(true);
        finger.SetActive(true);
    }
}
