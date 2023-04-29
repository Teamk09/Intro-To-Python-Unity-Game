using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public GameObject Box;

    public GameObject TextOb;
    public TMP_Text Text;

    public void ShowBox(bool isActive)
    {
        Box.SetActive(isActive);
    }

    public void DisplayText(bool isActive, string input)
    {
        TextOb.SetActive(isActive);
        Text.text = input;
    }
}
