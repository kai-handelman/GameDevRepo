using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObjectManager : MonoBehaviour {
    [SerializeField] private List<IPointerClickHandler> clickableObj = new List<IPointerClickHandler>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(IPointerClickHandler target in clickableObj)
            {
                target.OnPointerClick(null);
            }
        }
    }
}
