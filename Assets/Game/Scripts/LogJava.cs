using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogJava : MonoBehaviour, Interactable
{
    public DialogueBox sign;

    public void Interact()
    {
        Debug.Log("Java Clicked");
        StartCoroutine(PickJava());
    }

    IEnumerator PickJava()
    {
        sign.ShowBox(true);
        sign.DisplayText(true, "YOU HAVE SELECTED JAVA");

        yield return new WaitForSeconds(3f);

        sign.ShowBox(false);
        sign.DisplayText(false, "");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
