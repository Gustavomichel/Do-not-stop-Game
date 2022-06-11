using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class playerscript : MonoBehaviour
{

    //força do pulo
    [SerializeField]
    private float JumpForce;

    //pontuação
    [HideInInspector]
    public float score = 0;

    //verificações
    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    //Get components
    Rigidbody2D RB;
    [SerializeField]
    Collider2D standingcollider;
    [SerializeField]
    Animator animator;

    //texto e menu
    [Header("Texts and menus")]
    public GameObject GameOverMenu;
    public Text ScoreTxt;
    [HideInInspector]
    public float highscore;
    public Text highscoretxt;

    public bool playertwo = false;
    private bool jumped;
    private bool crouching;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        score = 0;
        highscore = PlayerPrefs.GetFloat("Highscore");
    }

    public void onJump(InputAction.CallbackContext context)
    {
        jumped = context.performed;
    }

    public void onCrouch(InputAction.CallbackContext context)
    {
        crouching = context.performed;
    }

    void Update()
    {
        //pular
        if (jumped)
        {
            if (isGrounded)
            {
                if (playertwo)
                {
                    RB.AddForce(Vector2.up * -JumpForce);
                }
                else
                {
                    RB.AddForce(Vector2.up * JumpForce);
                }
                isGrounded = false;
                animator.SetBool("isjumping", true);
            }
        }
        else
        {
            animator.SetBool("isjumping", false);
        }

        //agachar
        if (crouching && isGrounded)
        {
            standingcollider.enabled = false;
            animator.SetBool("iscrouch", true);
        }
        else
        {
            standingcollider.enabled = true;
            animator.SetBool("iscrouch", false);
        }


        //morto ou vivo?
        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "Pontuação : " + score.ToString("0000");
        }

        highscoretxt.text = "Highscore : " + highscore.ToString("0000");

        if (score > highscore)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //colindo com o chão?
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }
        //colindo com obstaculo?
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            isAlive = false;
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }

        //colindo com obstacuko no ar?
        if (collision.gameObject.CompareTag("AirObstacles"))
        {
            isAlive = false;
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }
    }


    //menu de restart, para o menu.
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
