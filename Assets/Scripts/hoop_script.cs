using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class hoop_script : MonoBehaviour
{
    public int score;
    public float time_to_die;
    GameObject score_sys;

    private void Awake()
    {
        score_sys = GameObject.FindGameObjectWithTag("ScoreSystem");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pole"))
        {
            collision.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            score_sys.GetComponent<score_system>().AddScore(score);
            Destroy(this.gameObject,time_to_die);
        }
    }
}
