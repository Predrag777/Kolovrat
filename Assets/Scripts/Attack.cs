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
        }
    }

    void performAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            Debug.Log("Attack");
            animator.SetBool("attack", true);
            isAttack = true;
        }
    }
}
