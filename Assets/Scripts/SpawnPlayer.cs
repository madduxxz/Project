using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab = null;

    [SerializeField] private GameObject hologramPlayer;
    [SerializeField] private Image characterMask;
    [SerializeField] private Material characterMaterial;
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
                  
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue()); 
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                hologramPlayer.transform.position = hit.point;
                if(Mouse.current.leftButton.wasPressedThisFrame && buttonSelected){
                Instantiate(cubePrefab, hit.point, Quaternion.identity);
                butt.interactable = false;
                characterMask.color = new Color(1f,1f,1f, 0.01f);
                anim.Play("ButtonDeselect");
                buttonSelected = false;
                }
            }


    }
}
