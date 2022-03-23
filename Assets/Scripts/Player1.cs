using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
	[ColorUsage(true, true)] public Color defaultColor1_Tile,defaultColor1_Piece, hightlightColor1, hightlightColor2, defaultColor2_Tile;
	[SerializeField] public string half1_Tile = "Half_1 Tile", half1_Piece = "Half1_Piece", half2_Tile = "Half_2 Tile";
	[SerializeField] private Vector3 offset;

	[HideInInspector]public Transform _selection;
	private bool selected = false;

	[SerializeField] Camera p1Camera;
	[SerializeField] GameController gameController;

	public GameObject[] selectedPieces_half1;

	void Start()
	{
		
	}
	
	private void Update()
	{
		
		if (_selection != null)
		{
			
			if (_selection.CompareTag(half1_Tile))
			{
				var selectionRenderer = _selection.GetComponent<Renderer>();
				selectionRenderer.material.SetColor("_OutLineColor", defaultColor1_Tile);
				_selection = null;
			}
			else if (_selection.CompareTag(half2_Tile))
			{
				var selectionRenderer = _selection.GetComponent<Renderer>();
				selectionRenderer.material.SetColor("_OutLineColor", defaultColor2_Tile);
				_selection = null;
			}
			else if(_selection.CompareTag(half1_Piece))
			{
				var selectionRenderer = _selection.GetComponent<Renderer>();
				selectionRenderer.material.SetColor("_Color", defaultColor1_Piece);
				_selection = null;
			}
			

		}
		
		Ray ray = p1Camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			var selection = hit.transform;
			if (selection.CompareTag(half1_Tile))
			{
				//Podświtlanie pola
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material.SetColor("_OutLineColor", hightlightColor1);
				}

				//Przenoszenie pionka na wybraną pozycję
				if (Input.GetMouseButtonDown(0) && selected && gameController.stPTurn)
				{			
					selectedPieces_half1 = GameObject.FindGameObjectsWithTag("Half1_Piece_Selected");
					selectedPieces_half1[0].GetComponent<Transform>().position = selection.position + offset;
					gameController.stPTurn = false;
					gameController.ndPTurn = true;
				}
				

				_selection = selection;
			}
			else if (selection.CompareTag(half2_Tile))
			{

				//Podświtlanie pola
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material.SetColor("_OutLineColor", hightlightColor2);
				}

				//Przenoszenie pionka na wybraną pozycję
				if (Input.GetMouseButtonDown(0) && selected && gameController.stPTurn)
				{
					selectedPieces_half1 = GameObject.FindGameObjectsWithTag("Half1_Piece_Selected");
					selectedPieces_half1[0].GetComponent<Transform>().position = selection.position + offset;
					gameController.stPTurn = false;
					gameController.ndPTurn = true;
				}

				_selection = selection;
			}
			
			else if (selection.CompareTag(half1_Piece))
			{
				//Podświtlanie pionka
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material.SetColor("_Color", hightlightColor1);
				}
				
				//Wybieranie pionka
				if (Input.GetMouseButtonDown(0))
				{
					selectedPieces_half1 = GameObject.FindGameObjectsWithTag("Half1_Piece_Selected");
					//Odznaczanie innych pionków
					for (int i = 0; i < selectedPieces_half1.Length; i++)
					{
						selectedPieces_half1[i].tag = half1_Piece;
						selectedPieces_half1[i].GetComponent<Renderer>().material.SetColor("_Color", defaultColor1_Piece);
					}
					selection.tag = "Half1_Piece_Selected";
					selected = true;
				}

				_selection = selection;
			}
			//Odznaczanie pionka
			else if (Input.GetMouseButtonDown(0) && selection.CompareTag("Half1_Piece_Selected"))
			{
				selection.tag = half1_Piece;
				selected = false;

			}
			
		}
	}
}
