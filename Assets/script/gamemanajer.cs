using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanajer : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    public AudioSource button;

    //transisi
    public Animator transisi;

    void Start()
    {
        transisi.Play("buka");
        //Debug.Log(PlayerPrefs.GetString("Score"));
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadkelv1()
    {
        button.Play();
        //SceneManager.LoadScene("level1");
        //transisi.Play("styleExpand");
        transisi.Play("tutup");
        StartCoroutine(gantisceneyuk());
    }

    public void keleaderbod()
    {
        button.Play();
        transisi.Play("tutup");
        StartCoroutine(gantileaderboard());
    }

    public void kemenu()
    {
        button.Play();
        transisi.Play("tutup");
        StartCoroutine(kembalimenu());
    }


    public void loadkelv2()
    {
        // button.Play();
        StartCoroutine(gantiscene());
    }

    private IEnumerator gantiscene()
    {
        yield return new WaitForSeconds(2);
        transisi.Play("tutup");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(index);
    }

    public void loadkelv0()
    {
        button.Play();
        transisi.Play("tutup");
        StartCoroutine(kembalikemenu());
    }

    private IEnumerator kembalikemenu()
    {
        //yield return new WaitForSeconds(2);
        //transisi.Play("tutup");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(6);
    }

    private IEnumerator gantisceneyuk()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("level1");
    }

    private IEnumerator gantileaderboard()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("leaderboard");
    }

    private IEnumerator kembalimenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("mainmenu");
    }
}
