using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanAI : MonoBehaviour
{
    private Animator animate;
    private Transform mtransform;
    public Transform attack;
    public float attackrange = 1f;
    private Rigidbody body;
    public GameObject player;
    bool move = true;
    bool isAttacking;
    public EnemyHealth health;


    private void Awake()
    {
        health = this.GetComponent<EnemyHealth>();
        isAttacking = false;
        animate = this.GetComponent<Animator>();
        mtransform = this.GetComponent<Transform>();
        body = this.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        animate.SetInteger("State", 4);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(mtransform.rotation);

        if (!health.dead)
        {
            Vector3 look = player.transform.position - mtransform.position;
            look.y = mtransform.position.y;
            Quaternion rot = Quaternion.LookRotation(look);
            mtransform.rotation = Quaternion.RotateTowards(mtransform.rotation, rot, 200 * Time.deltaTime);

            if (move)
                mtransform.position += mtransform.forward * 3 * Time.deltaTime;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, 3))
            {
                Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation; transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isAttacking)
        {
            isAttacking = true;
            move = false;
           
            int moveset = Random.Range(0, 2); Debug.Log(moveset);
            animate.SetInteger("State", moveset);
            //Invoke("Attack", 1f);

        }
    }
    void playMove()
    {
        move = true;
    
    }
    void Attack()
    {



        Collider[] hit = Physics.OverlapSphere(attack.position, attackrange);
        foreach (Collider obj in hit)
        {
            if (obj.tag == "Player")
                obj.GetComponent<playerScript>().takeDamage(5000);
        }


        animate.SetInteger("State", 4);
        isAttacking = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attack.position, attackrange);
    }
}
