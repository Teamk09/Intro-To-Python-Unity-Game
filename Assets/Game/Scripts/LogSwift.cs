using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogSwift : MonoBehaviour, Interactable
{
    public DialogueBox sign;


    public void Interact()
    {
        Debug.Log("Swift Clicked");
        StartCoroutine(PickSwift());
    }

    IEnumerator PickSwift()
    {
        sign.ShowBox(true);
        sign.DisplayText(true, "YOU HAVE SELECTED SWIFT. HE'S POOR FROM BUYING APPLE PRODUCTS");
        PlayerPrefs.SetInt("Choice", 3);


        yield return new WaitForSeconds(3f);

        sign.ShowBox(false);
        sign.DisplayText(false, "");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
