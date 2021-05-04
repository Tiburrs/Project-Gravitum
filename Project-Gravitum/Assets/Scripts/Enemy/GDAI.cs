using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDAI : MonoBehaviour
{
    private Animator animate;
    private Transform mtransform;
    public Transform attack;
    public float attackrange = 1f;
    private Rigidbody body;
    public GameObject player;
    bool isAttacking;
    private GameObject effect;
    float atkspeed, cooldown, burst, delay;
    public EnemyHealth health;
    public List<GameObject> vf = new List<GameObject>();

    private void Awake()
    {
        isAttacking = false;
        health = this.GetComponent<EnemyHealth>();
        animate = this.GetComponent<Animator>();
        mtransform = this.GetComponent<Transform>();
        body = this.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        burst = 3;
        cooldown = 3;
        atkspeed = cooldown;
        delay = .05f;
        effect = vf[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!health.dead)
        {
            if (!isAttacking)
            {
                animate.SetInteger("State", 4);
                Vector3 look = player.transform.position - mtransform.position;
                Quaternion rot = Quaternion.LookRotation(look);
                mtransform.rotation = Quaternion.RotateTowards(mtransform.rotation, rot, 200 * Time.deltaTime);
            }
            else if (atkspeed <= 0 && delay <= 0)
            {
                if (burst == 0)
                {
                    atkspeed = cooldown;
                    burst = 3;
                    isAttacking = false;
                    animate.SetInteger("State", 1);
                }
                else
                {
                    burst--;
                    Shoot();
                }
                delay = .5f;
            }
            RaycastHit hit;

            if (Physics.Raycast(mtransform.position + new Vector3(0f, .353f, 0f) + mtransform.forward * .4f, mtransform.forward, out hit) && atkspeed <= 0 && delay <= 0 && !isAttacking)
            {
                isAttacking = true;
                animate.SetInteger("State", 0);
                Debug.Log("Cast");
            }
            delay -= Time.deltaTime;
            atkspeed -= Time.deltaTime;
        }
       
    }

    
    public void Shoot()
    {
        GameObject vfx;

        if (attack != null)
        {
            vfx = Instantiate(effect, attack.position, Quaternion.identity);
            vfx.transform.localRotation = attack.rotation;
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
