using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballController : MonoBehaviour
{
    public float kecepatanjalan = 10;
    public Transform Balzz;
    public Transform Tangan;
    public Transform AtasKepala;
    public Transform PosDribble;
    public Transform Target;

    public float T = 0;

    private bool IsBallInHand = true;
    private bool IsBallFlying = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position += direction * kecepatanjalan * Time.deltaTime;
        transform.LookAt(transform.position + direction);

        if (IsBallInHand)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Balzz.position = AtasKepala.position;
                Tangan.localEulerAngles = Vector3.right * 180;


                transform.LookAt(Target.parent.position);
            }
            else
            {
                Balzz.position = PosDribble.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));
                Tangan.localEulerAngles = Vector3.right * 0;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                IsBallFlying = true;
                IsBallInHand = false;
                T = 0;
            }
        }


        if (IsBallFlying)
        {
            T += Time.deltaTime;
            float duration = 0.5f;
            float t01 = T / duration;

            Vector3 A = AtasKepala.position;
            Vector3 B = Target.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);

            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

            Balzz.position = pos + arc;

            if (t01 >= 1)
            {
                IsBallFlying = false;
                Balzz.GetComponent<Rigidbody>().isKinematic = false;
            }

        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Balls")
        {
            if (!IsBallInHand && !IsBallFlying)
            {
                IsBallInHand = true;
                Balzz.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

}

