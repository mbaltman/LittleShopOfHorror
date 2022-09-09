using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParamaters : MonoBehaviour
{
  //number of blood droplets for each level
  static public int [] num_blood = {2,7,9,10};

  //number of boxes on each level
  static public int [] num_boxes = {0,1,2,2};

  //number of wires on each level
  static public int [] num_wires = {1,1,1,3};

  //score needed to clear each level
  static public int [] score_goal = {1,10,12,16};



  //set index of cut scene for each level in order ( tutorial, level1, level2, level3)
  static public int [] next_scene_index = {2,3,4,5};

  //number of each character on each level
  static public int [] num_men     = {0,1,2,2};
  static public int [] num_seymour = {1,1,1,1};
  static public int [] num_dentist = {0,0,1,1};
  static public int [] num_audrey  = {0,0,0,1};

}
