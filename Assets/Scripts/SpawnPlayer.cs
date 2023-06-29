using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab = null;

    [SerializeField] private Image characterMask;
    private Animation anim;
    private Camera cam = null;
    private bool buttonSelected = false;
    private Button butt;
    
    private void Start(){
        anim = GetComponentInParent<Animation>();
        cam = Camera.main;
        butt = GetComponent<Button>();
        
    }

    public void OnMouseClicked()
    {
        buttonSelected = true;
        anim.Play("ButtonSelect");
        StartCoroutine("SpawningCoroutine");
        
    }

    private IEnumerator SpawningCoroutine()
    {
        while(buttonSelected){
        SpawnAtMousePos();
        yield return new WaitForEndOfFrame();
        }
    }
    public void SpawnAtMousePos()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)    
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;


            if(Physics.Raycast(ray, out hit))
            {
                Instantiate(cubePrefab, hit.point, Quaternion.identity);
            }
            buttonSelected = false;
            butt.interactable = false;
            characterMask.color = new Color(1f,1f,1f, 0.01f);
            anim.Play("ButtonDeselect");

        }
    }
}
