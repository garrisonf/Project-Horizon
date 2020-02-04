﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTile : MonoBehaviour
{
  public bool activated = false;
  private BoxTile[] neighbors = new BoxTile[4];
  private Collider2D player_collider;
  private static readonly Color activated_color = new Color(0f, 250f, 0f);
  private static readonly Color deactivated_color = new Color(0f, 0f, 0f);
  private static readonly string activation_key = "space";
  
  public void setNeighbors(BoxTile[] neighbors_list)
  {
    neighbors = neighbors_list;
  }
  
  void Awake()
  {
    player_collider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
  }
  
  void Update()
  {
    if (GetComponent<Collider2D>().IsTouching(player_collider))
    {
      if (Input.GetKeyDown(activation_key))
      {
        activated = !activated;
        foreach (BoxTile neighbor in neighbors)
          if (neighbor != null)
            neighbor.activated = !neighbor.activated;
      }
    }
    
    if (activated)
      GetComponent<SpriteRenderer>().color = activated_color;
    else
      GetComponent<SpriteRenderer>().color = deactivated_color;
  }
}
