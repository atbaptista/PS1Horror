using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Footstep : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip defaultFootstep;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //player is grounded and moving
        if(!(player.GetIsPlayerGrounded() && player.IsPlayerMoving())){
            footstepSource.enabled = false;
            return;
        }
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, 1 << 8); //1 << 8 is ground layermask

        if(!isHit){
            return;
        }

        //Debug.Log(hit.collider.name);

        switch (hit.collider.name){
            case "Floor":
                footstepSource.clip = defaultFootstep;
                footstepSource.enabled = true;
                //footstepSource.Play();
                break;
            // case "Dirt":
            //     footstepSource.clip = defaultFootstep;
            //     footstepSource.Play();
            //     footstepSource.gameObject.SetActive(true);
            //     break;
            default:
                footstepSource.clip = defaultFootstep;
                footstepSource.enabled = true;
                //footstepSource.gameObject.SetActive(true);
                break;
        }

    }
}
