using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab = null;
    [SerializeField] private Animation anim;
    private Camera cam = null;

   

    private bool buttonSelected = false;
    
    
    private void Start(){

        cam = Camera.main;
        
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
            anim.Play("ButtonDeselect");

        }
    }
}
