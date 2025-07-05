using UnityEngine;

public class Attack : MonoBehaviour
{
    bool isAttack;
    Animator animator;

    void Start()
    {
        isAttack = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        performAttack();
        performAttack2();
        if (isAttack)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("attack"))
            {
                if (stateInfo.normalizedTime >= 1.0f)
                {
                    animator.SetBool("attack", false);
                    isAttack = false;
                }
            }
            else if (stateInfo.IsName("attack2"))
            {
                if (stateInfo.normalizedTime >= 1.0f)
                {
                    animator.SetBool("attack2", false);
                    isAttack = false;
                }
            }
        }
    }

    void performAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            
            animator.SetBool("attack", true);
            isAttack = true;
        }
    }


    void performAttack2()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("attack2", true);
            isAttack = true;
        }
    }
}
