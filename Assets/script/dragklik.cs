using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dragklik : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;
    public ParticleSystem particle;
    public ParticleSystem glowing;
    public GameObject boll;
    public Canvas canvas;
    public Text Score;
    public Text totalscore;
    public Text gameoverscore;

    public static int scorevalue = 0;
    linerender tl;

    Camera cam;
    //Vector2 force;
    //Vector3 startPoint;
    //Vector3 endPoint;
    private bool nembak = false;

    //buat waktu
    public Text TextTimer;
    public float Waktu;
    public Canvas gameover;
    public bool gameaktif = true;

    //buat arah bola
    public Trajectory trajectory;
    public Ball ball;
    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    [SerializeField] float pushForce = 4f;
    bool isDragging = false;

    //buat rezise score
    public Animator animator;

    //audio sfx
    public AudioSource clap;
    public AudioSource hit;
    public AudioSource kecewa;

    //game manajer
    public gamemanajer other;
    public GameObject tangan;

    //confeti
    public meriah duar;

    void SetText()
    {
        int detik = Mathf.FloorToInt(Waktu % 60);
        TextTimer.text = detik.ToString("00");
        Score.text = ""+scorevalue;
    }

    float s;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<linerender>();
        glowing.Play();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "level1")
        {
            Waktu = 60;
            scorevalue = 0;
        }
        else
        {
            Waktu = PlayerPrefs.GetFloat("Waktu", Waktu);
        }
    }

    private void Update()
    {
        if (!nembak && gameaktif) {
            nembak = true;
            glowing.Stop();
            /*if (Input.GetMouseButtonDown(0))
             {
                 startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                 startPoint.z = 15;
                 //Debug.Log(startPoint);
                 //trajectory.Show();
             }

             if (Input.GetMouseButton(0))
             {
                 Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                 currentPoint.z = 15;
                 tl.RenderLine(rb.position, currentPoint);
                 //trajectory.UpdateDots(ball.pos, currentPoint); ;
             }

             if (Input.GetMouseButtonUp(0))
             {
                 endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                 endPoint.z = 15;

                 force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                 rb.AddForce(force * power, ForceMode2D.Impulse);
                 tl.EndLine();
                // trajectory.Hide();
             }*/

            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }
            if (Input.GetMouseButtonUp(0))
            {
                hit.Play();
                isDragging = false;
                OnDragEnd();
            }

            if (isDragging)
            {
                OnDrag();
                Destroy(tangan);
            }
            
        }


        if (gameaktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                Waktu--;
                s = 0;
            }
        }

        if (gameaktif && Waktu <= 0)
        {
            Debug.Log("gameover");
            kecewa.Play();
            gameoverscore.text = "" + scorevalue;
            gameaktif = false;
            gameover.enabled = true;
            //other.loadkelv0();
            duar.meledaksmua();
            string angka = scorevalue.ToString();
            PlayerPrefs.SetString("Score", angka);
            PlayerPrefs.Save();
        }

        SetText();
        float speed = rb.velocity.magnitude;
        //if(rb.velocity.x < 0.1f && rb.velocity.y < 0.1f)
        if(speed < 0.1)
        {
            nembak = false;
            glowing.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "lubang")
        {
            particle.Play();
            Destroy(boll);
            canvas.enabled = true;
            gameaktif = false;
            PlayerPrefs.SetFloat("Waktu", Waktu);
            //PlayerPrefs.SetFloat("Score", scorevalue);
            string angka = scorevalue.ToString();
            PlayerPrefs.SetString("Score", angka);
            PlayerPrefs.Save();
            totalscore.text = "" + scorevalue;
            clap.Play();
           

            other.loadkelv2();
        }

        if(collision.tag == "bintang")
        {
            animator.Play("scoresize");
            scorevalue +=10;
        }
    }

    void OnDragStart()
    {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        //trajectory.Show();
    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;


        //trajectory.UpdateDots(ball.pos, force);
        tl.RenderLine(ball.pos, endPoint);
    }

    void OnDragEnd()
    {
        //push the ball

        ball.Push(force);

        //trajectory.Hide();

        tl.EndLine();
    }

}
