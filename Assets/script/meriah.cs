using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meriah : MonoBehaviour
{
    public ParticleSystem meledak1;
    public ParticleSystem meledak2;

    public void meledaksmua()
    {
        StartCoroutine(duar());
    }

    private IEnumerator duar()
    {
        meledak1.Play();
        yield return new WaitForSeconds(0.4f);
        meledak2.Play();
    }

}
