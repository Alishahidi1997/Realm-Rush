using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordiantes = new Vector2Int();
    WayPoint getItsPlaceable;

    bool keepHide = false; 

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        getItsPlaceable = gameObject.GetComponentInParent<WayPoint>(); 
        DisplayCoordinates();
    }
    void Update()
    {
        DebuggerKey();

        LableColor();

        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectNames();
        }



    }

    private void DebuggerKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            HideDisplayLabels();
    }

    void HideDisplayLabels()
    {

        label.enabled = !label.enabled;
    }
    void DisplayCoordinates()
    {
        coordiantes.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordiantes.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.y);
        label.text = coordiantes.x.ToString() + "," + coordiantes.y.ToString();
    }

    void LableColor()
    {
        if (getItsPlaceable.IsPlaceable)
        {
            label.color = Color.white;
        }
        else
        {
            label.color = Color.black;
        }
    }

    void UpdateObjectNames()
    {
        transform.parent.name = label.text;
    }
}
