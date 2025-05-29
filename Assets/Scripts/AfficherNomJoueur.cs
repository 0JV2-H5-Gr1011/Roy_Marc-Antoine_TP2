using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AfficherNomJoueur : MonoBehaviour
{
    public TextMeshProUGUI texteNom;

    void Start()
    {
        texteNom.text = NomJoueurManager.nomJoueur;
    }
}
