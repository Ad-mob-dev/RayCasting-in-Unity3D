using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RayCast : MonoBehaviour
{
    public GameObject target;
    public LayerMask layerMask;
    public TMP_Text text;
    public Color originColor;
    public Color cngColor;
    // Start is called before the first frame update
    void Start()
    {

        text.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, ray.direction *100, Color.green);
     
                StartCoroutine(DisplayName(hit.transform.gameObject));
            }
            else
            {
                Debug.DrawRay(transform.position, ray.direction *100, Color.red);
            }
        }

        

       
    }
    IEnumerator DisplayName(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        originColor = obj.gameObject.GetComponent<MeshRenderer>().material.color;
        text.text = obj.transform.gameObject.name;
        text.color = originColor;
        text.faceColor = originColor;
        
        if (text.text == obj.transform.gameObject.name)
        {   
           yield return new WaitForSeconds(3f);
         text.text = "";
        }
    }
}
