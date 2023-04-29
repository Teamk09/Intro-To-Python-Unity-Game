using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogPython : MonoBehaviour, Interactable
{
    public DialogueBox sign;


    public void Interact()
    {
        Debug.Log("Python Clicked");
        StartCoroutine(PickPython());
    }

    IEnumerator PickPython()
    {
        sign.ShowBox(true);
        sign.DisplayText(true, "YOU HAVE SELECTED PYTHON. HE HAS SOME SERIOUS PYTHONS!");
        PlayerPrefs.SetInt("Choice", 1);


        yield return new WaitForSeconds(3f);

        sign.ShowBox(false);
        sign.DisplayText(false, "");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
