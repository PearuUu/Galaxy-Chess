using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] GameController gameController;
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

    
}
