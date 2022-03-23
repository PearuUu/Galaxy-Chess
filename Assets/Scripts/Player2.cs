using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
	[ColorUsage(true, true)] public Color defaultColor2_Tile, defaultColor2_Piece, hightlightColor2, hightlightColor1, defaultColor1_Tile;
	[SerializeField] public string half2_Tile = "Half_2 Tile", half2_Piece = "Half2_Piece", half1_Tile = "Half_1 Tile";
	[SerializeField] private Vector3 offset;
	
	[HideInInspector]public Transform _selection;
	private bool selected = false;

	[SerializeField] Camera p2Camera;
	[SerializeField] GameController gameController;

	public GameObject[] selectedPieces_half2;

	void Start()
	{
		
	}
	
	private void Update()
	{
		
		if (_selection != null)
		{
			
			
			if (_selection.CompareTag(half2_Tile))
			{
				var selectionRenderer = _selection.GetComponent<Renderer>();
				selectionRenderer.material.SetColor("_OutLineColor", defaultColor2_Tile);
				_selection = null;
			}
			
			else if(_selection.CompareTag(half2_Piece))
			{
				var selectionRenderer = _selection.GetComponent<Renderer>();
				selectionRenderer.material.SetColor("_Color", defaultColor2_Piece);
				_selection = null;
			}
			else if (_selection.CompareTag(half1_Tile))
			{
				var selectionRenderer = _selection.GetComponent<Renderer>();
				selectionRenderer.material.SetColor("_OutLineColor", defaultColor1_Tile);
				_selection = null;
			}

		}
		
		Ray ray = p2Camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			var selection = hit.transform;
			
			if (selection.CompareTag(half2_Tile))
			{
				//Podświtlanie pola
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material.SetColor("_OutLineColor", hightlightColor2);
				}

				//Przenoszenie pionka na wybraną pozycję
				if (Input.GetMouseButtonDown(0) && selected && gameController.ndPTurn)
				{
					selectedPieces_half2 = GameObject.FindGameObjectsWithTag("Half2_Piece_Selected");
					selectedPieces_half2[0].GetComponent<Transform>().position = selection.position + offset;
					gameController.stPTurn = true;
					gameController.ndPTurn = false;
				}

				_selection = selection;
			}
			else if (selection.CompareTag(half1_Tile))
			{
				//Podświtlanie pola
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material.SetColor("_OutLineColor", hightlightColor1);
				}

				//Przenoszenie pionka na wybraną pozycję
				if (Input.GetMouseButtonDown(0) && selected && gameController.ndPTurn)
				{
					selectedPieces_half2 = GameObject.FindGameObjectsWithTag("Half2_Piece_Selected");
					selectedPieces_half2[0].GetComponent<Transform>().position = selection.position + offset;
					gameController.stPTurn = true;
					gameController.ndPTurn = false;
				}


				_selection = selection;
			}


			else if (selection.CompareTag(half2_Piece))
			{
				var selectionRenderer = selection.GetComponent<Renderer>();
				if (selectionRenderer != null)
				{
					selectionRenderer.material.SetColor("_Color", hightlightColor2);
				}

				if (Input.GetMouseButtonDown(0))
				{
					selectedPieces_half2 = GameObject.FindGameObjectsWithTag("Half2_Piece_Selected");
					for (int i = 0; i < selectedPieces_half2.Length; i++)
					{
						selectedPieces_half2[i].tag = half2_Piece;
						selectedPieces_half2[i].GetComponent<Renderer>().material.SetColor("_Color", defaultColor2_Piece);
					}
					selection.tag = "Half2_Piece_Selected";
					selected = true;
				}
				
				_selection = selection;
			}
			else if (Input.GetMouseButtonDown(0) && selection.CompareTag("Half2_Piece_Selected"))
			{
				selection.tag = half2_Piece;
				selected = false;

			}
			
			
		}
	}
}
