using UnityEngine;
using UnityEngine.Playables;

public class CutseneTrigger : MonoBehaviour
{
    public PlayableDirector timelineDirector; 
    public GameObject player; 

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("Player"))
        {
            player.GetComponent<CharacterMovement>().enabled = false;

            if (timelineDirector != null)
            {
                timelineDirector.Play();

                timelineDirector.stopped += OnTimelineStopped;
            }
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        player.GetComponent<CharacterMovement>().enabled = true;

        timelineDirector.stopped -= OnTimelineStopped;

        Destroy(this.gameObject);
    }
}
