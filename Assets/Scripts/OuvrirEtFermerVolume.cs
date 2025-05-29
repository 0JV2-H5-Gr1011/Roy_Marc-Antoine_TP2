using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OuvrirEtFermerVolume : MonoBehaviour
{
    public GameObject volume;

    public void OuvrirVolume()
    {
        volume.SetActive(true);
    }

    public void FermerVolume()
    {
        volume.SetActive(false);
    }
}
