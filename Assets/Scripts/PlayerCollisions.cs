using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private string deathTag;
    [SerializeField] private string holeTag;

    public UnityEvent GameOver;
    public UnityEvent HolePassed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(deathTag))
        {
            GameOver?.Invoke();
        }

        if(other.CompareTag(holeTag))
        {
            HolePassed?.Invoke();
        }
    }
}
