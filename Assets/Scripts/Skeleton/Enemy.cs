using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 2;
    private bool isDead;
    private bool isImpact;
    private Player human;


    private Animator animator;
    private AnimatorStateInfo info;


    bool isAttack = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDead = false;
        isImpact = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if (info.IsName("attack") && info.normalizedTime >= 1.0f)
            {
                animator.SetBool("attack", false);
                isAttack = false;
            }
        }
    }


    void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        Debug.Log("U dometu si neprijatelju!!!");
        animator.SetBool("attack", true);
        isAttack = true;
    }
}

    void performAttack()
    {
        
    }
}
