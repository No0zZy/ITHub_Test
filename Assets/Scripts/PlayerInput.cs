using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public UnityEvent GetTouch;

    private void Update()
    {
        if (gameManager.State != GameState.Play)
            return;

        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
                GetTouch?.Invoke();
        }

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.Space))
            GetTouch?.Invoke();
#endif
    }
}
