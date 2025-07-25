using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillerAnimation : MonoBehaviour
{
    [SerializeField]private Animator Killeranim;
    [SerializeField]private NavMeshAgent KillerNavMeshAgent;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject FilmGrain;
    [SerializeField]private GameObject BlackScreen;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hover;
        if (Physics.Raycast(ray, out hover, 1500f))
        {

            if (hover.collider.CompareTag("Killer"))
            {
                Killeranim.SetTrigger("StartJumpscare");
                SoundManager.PlaySound(SoundType.ScreamingSound, 1f);
                KillerNavMeshAgent.SetDestination(Player.transform.position);
                
            }

            
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Killer"))
        {
            KillerNavMeshAgent.isStopped = true;
            FilmGrain.SetActive(true);
            Invoke("BadEnding", 2f);
        }
    }

    private void BadEnding()
    {
        BlackScreen.SetActive(true);
        SoundManager.PlaySound(SoundType.ThatSusSound, 1f);
        SoundManager.StopLoopSound();   
        
    }
}
