using UnityEngine;
using UnityEngine.Playables;

public class CutseneTrigger : MonoBehaviour
{
    public PlayableDirector timelineDirector; 
    GameObject player; 

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().CanMove = false;
            player = other.gameObject;
            if (timelineDirector != null)
            {
                timelineDirector.Play();

                timelineDirector.stopped += OnTimelineStopped;
            }
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        player.GetComponent<PlayerMovement>().CanMove = true;

        timelineDirector.stopped -= OnTimelineStopped;

        Destroy(this.gameObject);
    }
}
