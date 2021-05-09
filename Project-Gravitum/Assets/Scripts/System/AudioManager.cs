using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] random;
    public AudioSource player;

    float timer, count;
    // Start is called before the first frame update
    void Start()
    {
        count = 45;
        timer = count;
        player = this.GetComponent<AudioSource>();
        player.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            timer = count;
            playAudio();
        }

        timer -= Time.deltaTime;
    }

    void playAudio()
    {
        if (random.Length != 0)
        {
            int rand = Random.Range(0, random.Length);

            player.clip = random[rand];

            player.Play();
        }

    }
}
