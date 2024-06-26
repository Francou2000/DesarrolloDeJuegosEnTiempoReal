using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColectableItem
{
    void Bounce() { }

    public IEnumerator PlaySoundEffect();
}
