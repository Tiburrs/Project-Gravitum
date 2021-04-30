using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDAI : MonoBehaviour
{
    private Animator animate;
    private Transform mtransform;
    public Transform attack;
    public float attackrange = 1f;
    private Rigidbody body;
    public GameObject player;
    bool move = true;
    bool isAttacking;
    bool alive = true;
    public ParticleSystem explode;
    float jump, cooldown;
    public float ms;


    private void Awake()
    {
        ms = 1;
        isAttacking = false;
        animate = this.GetComponent<Animator>();
        mtransform = this.GetComponent<Transform>();
        body = this.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 2;
        jump = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Vector3 look = player.transform.position - mtransform.position;
            look.y = mtransform.position.y;
            Quaternion rot = Quaternion.LookRotation(look);
            mtransform.rotation = Quaternion.RotateTowards(mtransform.rotation, rot, 200 * Time.deltaTime);

            if (move)
                mtransform.position += mtransform.forward * ms * Time.deltaTime;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, 3))
            {
                Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.1f);
            }
            //ebug.DrawRay(mtransform.position+ new Vector3(0f, .353f, 0f)+mtransform.forward*.4f, mtransform.forward*3, Color.green, 1);
            if (Physics.Raycast(mtransform.position + new Vector3(0f, .353f, 0f) + mtransform.forward * .4f, mtransform.forward, out hit, 9) && jump <= 0)
            {
                // Debug.Log(hit.transform.name);
               
                body.AddForce((mtransform.forward + mtransform.up).normalized * 6, ForceMode.Impulse);
                jump = cooldown;
            }
            jump -= Time.deltaTime;
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isAttacking)
        {
            //Debug.Log(other.name);
           // isAttacking = true;
            move = false;
          
            explode.Play();
            Attack();

        }
    }
   
    void Attack()
    {



        Collider[] hit = Physics.OverlapSphere(attack.position, attackrange);
        foreach (Collider obj in hit)
        {
            if (obj.tag == "Player")
                Debug.Log(obj.name);
        }



        animate.SetTrigger("Dead");
        alive = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attack.position, attackrange);
    }
}
