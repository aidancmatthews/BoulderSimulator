using System;
using UnityEngine;

public class music_script : MonoBehaviour
{
    public GameObject player;
    public GameObject boulder;
    public AudioSource audioSource;
    public GameObject ui;
    private bool isPlaying = false;
    public int acceptableDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }

        if (boulder == null)
            player = GameObject.FindGameObjectsWithTag("Boulder")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying && OutOfRange())
        {
            audioSource.volume = 0.068F;
            audioSource.Play();
            isPlaying = true;
            Camera.main.transform.LookAt(boulder.transform);
            ui.SetActive(true);
        }

    }

    private bool OutOfRange()
    {
        float distance = Math.Abs(boulder.transform.position.z - player.transform.position.z);
        return distance > acceptableDistance;
    }
}
