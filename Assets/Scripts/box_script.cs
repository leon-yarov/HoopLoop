using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class box_script : MonoBehaviour
{
    public GameObject[] hoops; //Store Different Types of hoops
    public AudioClip[] wooshes; //Store Different Types of sounds
    public float hoop_torque;
    public int max_hoops;
    public float gravity;
    public float force;

    private Vector3 fake_mouse_pos;
    private Vector3 mouse_delta;
    private Vector3 mouse_pos;
    private LineRenderer line;
    private Camera cam;
    private float mouse_time;
    private int _max_hoops;

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
        TossHoop(); //throw hoop
        CheckMaxHoopCount(); //check if hoop count dont exceed the limit
    }
    void LateUpdate()
    {
        mouse_delta = Input.mousePosition; //register mouse position on the next frame to get its delta
    } 
    private void TossHoop()
    {
        mouse_pos = Input.mousePosition; //reference mouse position

        if (Input.GetMouseButton(0) && Time.timeScale > 0) //User Presses Left Mouse Button, also check if game is not paused
        {
            fake_mouse_pos += cam.ScreenToWorldPoint(mouse_pos) - cam.ScreenToWorldPoint(mouse_delta); //register fake mouse position

            line.SetPosition(1, Vector3.Lerp(transform.position, fake_mouse_pos, 0.55f)); //last line point is half shorter than mouse actual position, see .Lerp 
            line.SetPosition(0, transform.position); //first line point starts at the box

            mouse_time += Time.deltaTime; //when user holds the mouse, count the time he is holding it
        }
        else if (Input.GetMouseButtonUp(0) && Time.timeScale > 0) //When user releases the button, also check if not paused
        {
            var hoop_rb = Instantiate(randomHoop(), this.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>(); //create hoop and get its rigidbody component

            hoop_rb.gameObject.transform.parent = transform; //assign parent 
            hoop_rb.gravityScale = gravity; //give weigth to the hoop
            hoop_rb.AddForce((fake_mouse_pos - transform.position) * force * (1 / mouse_time)); //launch hoop
            hoop_rb.AddTorque(Random.Range(-hoop_torque, hoop_torque)); //add torque to the hoop

            fake_mouse_pos = transform.position; //set the fake mouse position to box's position (reset)

            _max_hoops++; //increment hoop count

            GetComponent<AudioSource>().PlayOneShot(wooshes[Random.Range(0, wooshes.Length)]); //play sound on hoop launch

            mouse_time = 0; // set mouse time to 0 (reset)
        }
    } //toss hoop from the box
    private void CheckMaxHoopCount()
    {
        int hoops = 0;
        foreach (Transform child in transform) { hoops++; }

        _max_hoops = hoops;

        if (_max_hoops > max_hoops) { Destroy(transform.GetChild(0).gameObject); }
    }
    private GameObject randomHoop()
    {
        return hoops[Random.Range(0, hoops.Length)];
    } //select random object from the list

}
