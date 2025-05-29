using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NomManager : MonoBehaviour
{
    public TMP_InputField champNom;

    public void LireTexte()
    {
        string texteEntre = champNom.text;
        Debug.Log("Texte saisi : " + texteEntre);
    }
}