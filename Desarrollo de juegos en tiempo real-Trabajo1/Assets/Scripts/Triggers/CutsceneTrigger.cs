using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector timelineDirector; 
    GameObject player; 

    private void OnTriggerEnter2D(Collider2D collider)
    {   
        PlayerMovement other = collider.GetComponent<PlayerMovement>();
        if (other != null)
        {
            other.CanMove = false;
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
