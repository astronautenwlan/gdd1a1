using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFieldToggleScript : MonoBehaviour
{
    public bool is_hidden_ = false;

    void Awake()
    {
        if (is_hidden_ == true)
        {
            this.gameObject.SetActive(false);
        }
    }
    
}
