using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProj : MonoBehaviour
{

    public GameObject fire;
    public List<GameObject> vf = new List<GameObject>();

    private GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        effect = vf[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
 GameObject vfx;

        if(fire != null)
        {   
            vfx = Instantiate(effect, fire.transform.position, Quaternion.identity);
            vfx.transform.localRotation = fire.transform.rotation;
        }
        else
        {
            Debug.Log("No Fire Point");
        }

    }
}
