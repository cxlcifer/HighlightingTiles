using UnityEngine;
using UnityEngine.Serialization;

public class Recolor : MonoBehaviour
{
    public GameObject _prevSelectable;
    
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var currentSelectable = hitInfo.collider.gameObject;
            
            if (currentSelectable != null && !currentSelectable.GetComponent<Unselect>())
            {
                if (_prevSelectable && _prevSelectable != currentSelectable)
                {
                    Deselect(_prevSelectable,Color.white);
                }
                _prevSelectable = currentSelectable;
                Select(currentSelectable, Color.gray);
            }
            else
            {
                if (_prevSelectable != null)
                {
                    Deselect(_prevSelectable,Color.white);
                }
            }
        }
        else
        {
            if (_prevSelectable != null)
            {
                Deselect(_prevSelectable, Color.white);
            }
        }
    }

    void Select(GameObject gameObject, Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    void Deselect(GameObject gameObject, Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
    
}