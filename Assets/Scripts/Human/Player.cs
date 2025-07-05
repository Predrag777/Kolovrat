using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 10;
    private bool isAttack;
    private bool isDead;
    private bool isImpact;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool getIsAttack()
    {
        return isAttack;
    }
}
