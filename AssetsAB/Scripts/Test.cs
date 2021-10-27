using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    TestMono,
    String,
    Color,
}


public class Test : MonoBehaviour
{
    [HideInInspector]
    public Type type;
    [HideInInspector]
    public Test test;
    [HideInInspector]
    public string str;
    [HideInInspector]
    public Color color;
}
