using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SpawnPlayer : MonoBehaviour
{
    private GameObject player = null;
    private GameObject hologramPlayer;
    [SerializeField] private Image characterMask;
    private Material characterMaterial;
    public Card card;
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
        player = card.playerCharacter;
        characterMaterial = card.playerMat;
        buttonSelected = true;
        anim.Play("ButtonSelect");
        hologramPlayer = Instantiate(player, transform.position, Quaternion.identity);
        characterMaterial.color = new Color(characterMaterial.color.r, 
        characterMaterial.color.b,characterMaterial.color.g, 0.4f);
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
                Instantiate(player, hit.point, Quaternion.identity);
                butt.interactable = false;
                characterMaterial.color = new Color(characterMaterial.color.r, 
                characterMaterial.color.b,characterMaterial.color.g, 1f);
                characterMask.color = new Color(1f,1f,1f, 0.01f);
                anim.Play("ButtonDeselect");
                buttonSelected = false;
                Destroy(hologramPlayer);
                }
            }
    }
}
