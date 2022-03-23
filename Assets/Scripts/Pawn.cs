using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField]Vector3 dir1,dir2, offset;
    [SerializeField] private float maxdistance, angle = -15f;
    public bool normalize;
    
    
    
    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Half1_Piece" && gameController.stPTurn)
        {
            Destroy(other.transform.parent.gameObject);

        }
        else if (other.tag == "Half2_Piece" && gameController.ndPTurn)
        {
            Destroy(other.transform.parent.gameObject);

        }

    }

    void Update()
    {
        WhereCanGo();
    }

    void WhereCanGo()
    {
        if (normalize)
        {
            dir1.Normalize();
        }
        
        
        Debug.DrawRay(transform.position + offset, dir1, Color.green);
        Debug.DrawRay(transform.position + offset, dir2, Color.red);
        //Debug.DrawRay(transform.position, Vector3.left, Color.white);

        Ray ray1 = new Ray(transform.position + offset, dir1);
        
        RaycastHit hit;
        if (Physics.Raycast(ray1, out hit, maxdistance))
        {
            Debug.Log(hit.transform.name);
        }
        else
        {
            Debug.Log("Ray not hit anything");
        }
    }
}
