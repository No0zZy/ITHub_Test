using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform beginPoint;
    public Transform BeginPoint => beginPoint;
    [SerializeField] private Transform endPoint;
    public Transform EndPoint => endPoint;
    [SerializeField] private FloatValue speed;

    [SerializeField] private Hole hole;
    public Hole Hole => hole;

    public void Move()
    {
        transform.Translate(Vector3.left * speed.Value);
    }
}
