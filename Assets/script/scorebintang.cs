using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorebintang : MonoBehaviour
{
 
    public ParticleSystem bintangpecah;
    public ParticleSystem kelip2;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public AudioSource audiodata;

    private void Awake()
    {
       // bintangpecah = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("nabrak");
        Destroy(kelip2);
        StartCoroutine(mbledos());
    }

    private IEnumerator mbledos()
    {
        audiodata.Play();
        bintangpecah.Play();
        sr.enabled = false;
        bc.enabled = false;
        yield return new WaitForSeconds(bintangpecah.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
