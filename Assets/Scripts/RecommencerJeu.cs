using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecommencerJeu : MonoBehaviour
{
    public void Recommencer()
    {
        SceneManager.LoadScene("accueil");
    }
}
