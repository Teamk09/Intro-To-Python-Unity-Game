using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public int UserPokemon;

    public void UserChoice(string Pick)
    {
        if (Pick == "Python")
            UserPokemon = 1;
        else if (Pick == "Java")
            UserPokemon = 2;
        else
            UserPokemon = 3;

    }
}
