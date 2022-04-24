using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UInterface : MonoBehaviour
{
    public List<Popup> Popups = new List<Popup>();

    public void OpenPopup(Popup popup)
    {
        foreach (var pop in Popups)
        {
            pop.gameObject.SetActive(pop == popup);
        }
    }
}
