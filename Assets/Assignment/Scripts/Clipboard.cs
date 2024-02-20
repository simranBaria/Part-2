using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clipboard : MonoBehaviour
{
    public TextMeshProUGUI dialogue;

    // Method to change the text of the clipboard
    public void ChangeText(string text)
    {
        dialogue.text = text;
    }
}
