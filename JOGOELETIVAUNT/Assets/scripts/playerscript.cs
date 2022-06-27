using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerscript : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    
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
    private bool agachar;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        score = 0;
        highscore = PlayerPrefs.GetFloat("Highscore");
        life = hearts.Length;
    }

    public void Jump()
    {
        if (!playertwo)
        {
            //pular
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                   if (isGrounded && !agachar)
                   {
                       RB.AddForce(Vector2.up * JumpForce);
                       isGrounded = false;
                       animator.SetBool("isjumping", true);
                   }
            } 
            else
            {
                animator.SetBool("isjumping", false);
            }
        }
        else if (playertwo)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (isGrounded && !agachar)
                {
                    RB.AddForce(Vector2.up * JumpForce);
                    isGrounded = false;
                    animator.SetBool("isjumping", true);
                }
            }
            else
            {
                animator.SetBool("isjumping", false);
            }
        }
            
    }
    public void Crouch()
    {
        agachar = Input.GetKey(KeyCode.DownArrow);
        if (playertwo)
        {
            agachar = Input.GetKey(KeyCode.S);
        }
        
            //agachar
            if (agachar && isGrounded)
            {
                
                standingcollider.enabled = false;
                animator.SetBool("iscrouch", true);
            }
            else
            {
                
                standingcollider.enabled = true;
                animator.SetBool("iscrouch", false);
            }

    }

    void Update()
    {
        Jump();
        Crouch();

        if (score > highscore)
        {
            PlayerPrefs.SetFloat("Highscore", score);
            highscoretxt.text = "HI : " + highscore.ToString("0000");
        }

        //morto ou vivo?
        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "Pontuação : " + score.ToString("0000");
            highscoretxt.text = "Highscore : " + highscore.ToString("0000");
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
        if(life >= 1)
        {
          //colindo com obstaculo?
            if (collision.gameObject.CompareTag("Obstacles"))
            {
                life -= 1;
                Destroy(hearts[life].gameObject);
                if(life <= 0)
                {
                    isAlive = false;
                    Time.timeScale = 0;
                    GameOverMenu.SetActive(true);
                }
            }

            //colindo com obstaculo no ar?
            if (collision.gameObject.CompareTag("AirObstacles"))
            {
                life -= 1;
                Destroy(hearts[life].gameObject);
                if (life <= 0)
                {
                    isAlive = false;
                    Time.timeScale = 0;
                    GameOverMenu.SetActive(true);
                }
            }
        }
        
    }


    //menu de restart, para o menu.
    public void RestartLevel()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
