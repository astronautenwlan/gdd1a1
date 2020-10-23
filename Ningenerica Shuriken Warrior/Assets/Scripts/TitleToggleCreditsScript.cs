using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TitleToggleCreditsScript
    : MonoBehaviour
{
    private Text[] sub_fields_;

    private void Awake()
    {
        sub_fields_ = GetComponentsInChildren<Text>();
    }

    public void toggleMenuCredits()
    {
        foreach (Text t in sub_fields_)
        {
            TextFieldToggleScript toggle = t.GetComponent<TextFieldToggleScript>();
            if (toggle != null)
            {
                if (toggle.is_hidden_)
                {
                    t.gameObject.SetActive(true);
                    toggle.is_hidden_ = false;
                }
                else
                {
                    t.gameObject.SetActive(false);
                    toggle.is_hidden_ = true;
                }
            }

        }
    }
}
