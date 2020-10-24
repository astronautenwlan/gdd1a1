using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteScript : MonoBehaviour
{
    public Sprite normal_sprite_;
    public Sprite frozen_sprite_;
    
    public void applyFrozenSprite ()
    {
        SpriteRenderer s = this.GetComponent<SpriteRenderer>();
        if (s != null)
        {
            s.sprite = frozen_sprite_;
        }
    }

    public void applyNormalSprite()
    {
        SpriteRenderer s = this.GetComponent<SpriteRenderer>();
        if (s != null)
        {
            s.sprite = normal_sprite_;
        }
    }

}
