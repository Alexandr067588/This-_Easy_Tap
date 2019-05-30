using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Im here");
       Application.LoadLevel("test");
    }
}
