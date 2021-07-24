using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FloatValue", menuName = "FloatValue", order = 51)]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float value;
    public float Value { get => value; set => this.value = value; }
}
