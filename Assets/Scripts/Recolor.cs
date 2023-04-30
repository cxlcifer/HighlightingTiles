using UnityEngine;

public class Recolor : MonoBehaviour
{
    public GameObject _currentSelectable;
    private Color _currentColor;

  
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var selectable = hitInfo.collider.gameObject;
            _currentColor = selectable.GetComponent<Renderer>().material.color;
            

            if (selectable)
            {
                if (_currentSelectable && _currentSelectable != selectable)
                {
                    Deselect(_currentSelectable,_currentColor);
                }
                _currentSelectable = selectable;
                Select(_currentSelectable,Color.gray);
            }
            else
            {
                if (_currentSelectable)
                {
                    Deselect(_currentSelectable,_currentColor);
                }
            }
        }
        else
        {
            if (_currentSelectable)
            {
                Deselect(_currentSelectable, _currentColor);
            }
        }
    }

    void Select(GameObject gameObject, Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    void Deselect(GameObject gameObject, Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = _currentColor;
    }
    
}
