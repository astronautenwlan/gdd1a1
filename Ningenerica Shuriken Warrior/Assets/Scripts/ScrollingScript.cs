using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//Parallax Scrolling script

public class ScrollingScript : MonoBehaviour
{
    public Vector2 scrolling_speed_ = new Vector2(2, 2);
    public Vector2 scrolling_direction_ = new Vector2(-1, 0);
    public float respawn_offset_ = 0;
    
    // set variable that movement should be applied to camera
    public bool is_linked_to_camera_ = false;
    
    public bool is_looping_ = false;

    // list of children with a renderer
    private List<SpriteRenderer> background_part;
    
    // get all those children
    void Start()
    {
        if (is_looping_)
        {
            //for infinite backgrounds, get all the children of the layer with a renderer
            background_part = new List<SpriteRenderer>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer r = child.GetComponent<SpriteRenderer>();
                
                // add only visible children
                if (r != null)
                {
                    background_part.Add(r);
                }
            }
            
            //Sort children by position, get them from left to right
            background_part = background_part.OrderBy(t => t.transform.position.x).ToList();
        }
    }

    
    
    // Update is called once per frame
    void Update()
    {
        Vector3 scrolling_movement = new Vector3(
            scrolling_speed_.x * scrolling_direction_.x,
            scrolling_speed_.y * scrolling_direction_.y,
            0);
        scrolling_movement *= Time.deltaTime;
        transform.Translate(scrolling_movement);

        // Move the Camera
        if (is_linked_to_camera_)
        {
            Camera.main.transform.Translate(scrolling_movement);
        }
        
        //implement the loop
        if (is_looping_)
        {
            //Get the first object from ordered list
            SpriteRenderer first_child = background_part.FirstOrDefault();

            if (first_child != null)
            {
                //first the cheaper check, if the first child is already (partly) before the camera (the isVisibleFrom is expensive)
                if (first_child.transform.position.x < Camera.main.transform.position.x)
                {
                    //if the first child's x position is already left of the camera, only then we check if it's still visible
                    if (!first_child.isVisibleFrom(Camera.main))
                    {
                        //if not visible anymore, get the last child's position
                        SpriteRenderer last_child = background_part.LastOrDefault();
                        Vector3 last_position = last_child.transform.position;
                        Vector3 last_size = (last_child.bounds.max - last_child.bounds.min);
                        
                        //then we set the position of the recycled first Sprite to be after the last one
                        first_child.transform.position = new Vector3(
                           last_position.x + last_size.x + respawn_offset_,
                            first_child.transform.position.y,
                            first_child.transform.position.z);
                        
                        //and lastly update our background particles list
                        background_part.Remove(first_child);
                        background_part.Add(first_child);

                    }
                }
            }
        }
    }
}
