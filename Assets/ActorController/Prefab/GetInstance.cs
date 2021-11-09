using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInstance : MonoBehaviour
{
    public string str = "name";

    private static GetInstance instance;

    private GetInstance()
    {

    }

    public static GetInstance Instance
    {
        get
        {
            if (instance == null)
                instance = new GetInstance();
            return instance;
        }
    }
}
