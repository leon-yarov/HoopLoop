using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class hoop_script : MonoBehaviour
{
    private GameObject score_sys;

    public float time_to_die; //time until the hoop is destoyed
    public int score; //score amout

    private void Awake() //when object's script created find the game's score component
    {
        score_sys = GameObject.FindGameObjectWithTag("ScoreSystem");
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("pole")) // if trigger collider touches pole collider
        {
            collision.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play(); //play particle system
            score_sys.GetComponent<score_system>().AddScore(score); //add score
            Destroy(this.gameObject,time_to_die); //destoy the hoop
        }
    }
}
