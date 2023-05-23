using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class striker : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody;
    CircleCollider2D coll;
    Transform selftrans;
    Vector2 startpos;
    public Slider myslider;
    Vector2 direction;
    Vector3 mousepos;
    Vector3 mousepos2;
    public LineRenderer line;
    bool hasStriked=false;
    bool positionset=false;
    public GameObject bord;
    bool no = true;




    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        selftrans = transform;
        startpos = transform.position;
        coll = GetComponent<CircleCollider2D>();
    }

    public void shootstriker()
    {
        float x = 0;
        if(positionset && rigidbody.velocity.magnitude ==0)
        {
            x = Vector2.Distance(transform.position, mousepos);
        }
        direction = (Vector2)(mousepos2- transform.position);
        direction.Normalize();
        rigidbody.AddForce(direction *x* 300);
        hasStriked= true;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            no = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            no = true;
        }
    }

    // Update is called once per frame
    void Update()

    {  
        line.enabled = false;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos2 = new Vector3(-mousepos.x, -mousepos.y, mousepos.z);
       
        if (!hasStriked && !positionset)
        {
            selftrans.position = new Vector2(myslider.value, startpos.y);
        }

        if (Input.GetMouseButtonUp(0) && rigidbody.velocity.magnitude == 0 && positionset)
        {
            shootstriker();
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {



            if (Input.GetMouseButtonDown(0))
            {
                if (!positionset)
                {
                    positionset = true;
                }
            }
        }
        if (positionset && rigidbody.velocity.magnitude == 0)
        {
            line.enabled = true;
            line.SetPosition(0, selftrans.position);
            line.SetPosition(1, mousepos2);
        }
        if (rigidbody.velocity.magnitude<0.2f && rigidbody.velocity.magnitude != 0)
        {
            strikerreset();
            bord.GetComponent<gameman>().count++;
        }

         
    }
    public void strikerreset()
    {
        rigidbody.velocity = Vector2.zero;
        hasStriked= false;
        positionset= false; 
        line.enabled = true;
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
