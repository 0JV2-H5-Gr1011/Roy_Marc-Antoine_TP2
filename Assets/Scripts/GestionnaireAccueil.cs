using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionnaireAccueil : MonoBehaviour
{

    [SerializeField] private TMP_InputField _nomInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
        public void PartirJeu()
    {

        if (_nomInput.text == "")
        {

            _nomInput.placeholder.GetComponent<TMP_Text>().text = "Met ton nom...";

        }
        else
        {


            GameManager.instance.nomJoueur = _nomInput.text;
            GameManager.instance.nbItems = 0;

            SceneManager.LoadScene("Niveau1");

        }

    }

}
