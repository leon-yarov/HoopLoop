using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class box_script : MonoBehaviour
{
    public GameObject[] hoops;
    public float force;
    public float gravity;
    public int max_hoops;
    private int _max_hoops;
    Vector3 mouse_pos;
    Vector3 mouse_delta;
    Vector3 fake_mouse_pos;
    float mouse_time;
    Camera cam;
    LineRenderer line;
    public AudioClip[] wooshes;

    void Start()
    {
        cam = Camera.main; //get main camera compenent
        line = GetComponent<LineRenderer>(); //get the line compenent
        line.SetPosition(1, Vector3.zero); //set the first position of line to zero
        line.SetPosition(0, Vector3.zero);// set the second position of line to zero
        fake_mouse_pos = transform.position; //set the fake mouse position to box's position
    }

    void Update()
    {
        mouse_pos = Input.mousePosition; //reference mouse position

        if (Input.GetMouseButton(0) && Time.timeScale > 0)
        {
            fake_mouse_pos += cam.ScreenToWorldPoint(mouse_pos) - cam.ScreenToWorldPoint(mouse_delta);
            mouse_time += Time.deltaTime;
            line.SetPosition(1, Vector3.Lerp(transform.position, fake_mouse_pos, 0.55f));
            line.SetPosition(0, transform.position);
        }
        else if (Input.GetMouseButtonUp(0) && Time.timeScale > 0)
        {
            var rb = Instantiate(randomHoop(),this.transform.position ,Quaternion.identity).GetComponent<Rigidbody2D>();
            rb.gameObject.transform.parent = transform;
            rb.gravityScale = gravity;
            rb.AddForce((fake_mouse_pos - transform.position ) * force * (1 / mouse_time));
            rb.AddTorque(Random.Range(-50,50));
            fake_mouse_pos = transform.position;
            mouse_time = 0;
            _max_hoops++;
            GetComponent<AudioSource>().PlayOneShot(wooshes[Random.Range(0, wooshes.Length)]);
        }

            int i = 0;
        foreach (Transform child in transform)
            i++;
        _max_hoops = i;
        if (_max_hoops > max_hoops)
            Destroy(transform.GetChild(0).gameObject);
    }
    void LateUpdate()
    {
        mouse_delta = Input.mousePosition;
    }

    private GameObject randomHoop()
    {
        return hoops[Random.Range(0, hoops.Length)];
    }

    private void OnDrawGizmos()
    {
        if (Input.GetMouseButton(0))
        {
            Gizmos.DrawLine(transform.position, fake_mouse_pos);
        }
        
    }
}
