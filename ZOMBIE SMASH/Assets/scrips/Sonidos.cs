using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public AudioSource audi;
    public AudioClip elSonido;
    public void Sonido()
    {
        AudioSource.PlayClipAtPoint(elSonido, gameObject.transform.position);
    }
}
