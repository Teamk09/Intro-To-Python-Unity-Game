using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour, Interactable
{
    public DialogueBox sign;

    public void Interact()
    {
        Debug.Log("Sign Clicked");
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        sign.ShowBox(true);
        sign.DisplayText(true, "TO SELECT YOUR PROGRAMMING LANGUAGE, APPROACH YOUR PREFERRED LANGUAGE AND PRESS 'E'.");

        yield return new WaitForSeconds(5f);

        sign.ShowBox(false);
        sign.DisplayText(false, "");
    }


}
