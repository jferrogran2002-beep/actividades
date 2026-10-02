using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    public bool isAggro;
    public float distanceToAggro;
    [HideInInspector] public Transform playerTransform;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = FindAnyObjectByType<PlayerMovement>().transform;
        }
        isAggro = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyAggro();
    }
    public void CheckEnemyAggro()
    {
        animator.SetBool("isAttacking", isAggro);
    var dis = Vector3.Distance(transform.position, playerTransform.position);
        if (dis > distanceToAggro)
        {
            isAggro = false;
        }
        else
        {
            isAggro = true;
        }
    }
    public void EnemyDamage()
    {
        playerTransform.GetComponent<PlayerStats>().PlayerDamage();
        Debug.Log("La vida del jugador reduce a " + playerTransform.GetComponent<PlayerStats>().health);
    }
}
