using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    Transform obj;
    TapReader tapScript = new TapReader();

    // i dont understand this stuff i did but it gives health a variable changed event so its goated
    public int maxHealth;
    public int health = 3;
    private int healthVar
    {
        get { return health; }
        set
        {
            if (health == value) return;
            if (health > value) { VariableChangeDown(health, value); } //if goes up
            //if (health < value) {  } // if goes down
            health = value;
            
        }
    }

    public GameObject[] Hearts;

    AudioSource audioSource;
    public AudioClip hurtSound;
    public AudioClip deathSound;

    public bool dashing = false;

    private GameObject checkpoint;

    void Start()
    {
        audioSource = Camera.main.GetComponent<AudioSource>();
    }

    private void VariableChangeDown(int var, int newvar)
    {
        //Debug.Log("hurt");
        Hearts[newvar].gameObject.GetComponent<Image>().color = new Color(1,1,1, 0f);
        Hearts[newvar].transform.Find("BrokenImage").gameObject.SetActive(true);
        audioSource.PlayOneShot(hurtSound, 1.0F);
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Ground") {
        tapScript.isGrounded = 0;
        }
        else if (collider.gameObject.tag == "BreakableWall")
        {

            if (dashing == false)
            {


                healthVar--;

                if (healthVar == 0)
                { //DEATH

                    //transform.DetachChildren();
                    //Destroy(this.gameObject);
                    obj = GetComponent<Transform>();

                    audioSource.PlayOneShot(deathSound, 1.0F);

                    checkpoint = gameObject.GetComponent<ActivateCheckpoint>().currentCheckpoint;
                    if (checkpoint != null)
                    {
                        obj.position = checkpoint.transform.position;
                    }
                    else
                    {
                        obj.position = Vector3.zero;
                    }

                    healthVar = maxHealth;
                    for (int i = 0; i < Hearts.Length; i++)
                    {
                        Hearts[i].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                        Hearts[i].transform.Find("BrokenImage").gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                Destroy(collider.gameObject);
            }
        }
        else if (collider.gameObject.tag == "Obstacle") {
                healthVar--;

                if (healthVar == 0) { //DEATH

                    //transform.DetachChildren();
                    //Destroy(this.gameObject);
                    obj = GetComponent<Transform>();

                    audioSource.PlayOneShot(deathSound, 1.0F);

                    checkpoint = gameObject.GetComponent<ActivateCheckpoint>().currentCheckpoint;
                    if (checkpoint != null)
                    {
                        obj.position = checkpoint.transform.position;
                    }
                    else
                    {
                        obj.position = Vector3.zero;
                    }

                    healthVar = maxHealth;
                    for (int i = 0; i < Hearts.Length; i++)
                    {
                        Hearts[i].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
                        Hearts[i].transform.Find("BrokenImage").gameObject.SetActive(false);
                    }
                }

            }

    }



}
