using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clipboard : MonoBehaviour
{
    public TextMeshProUGUI dialogue;

    public void ChangeText(string text)
    {
        dialogue.text = text;
    }
}
