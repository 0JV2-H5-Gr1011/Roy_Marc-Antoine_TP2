using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LancerJeu : MonoBehaviour
{
    public TMP_InputField inputNom;


    public void LancerNiveau1()
    {
        NomJoueurManager.nomJoueur = inputNom.text;
        SceneManager.LoadScene("Niveau1");
    }
}