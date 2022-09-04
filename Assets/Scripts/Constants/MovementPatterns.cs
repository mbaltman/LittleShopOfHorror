using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPatterns: MonoBehaviour
{
  public static int [,] plant_day1_mp ={{1,1},
                                        {1,-1},
                                        {-1,1},
                                        {-1,-1}};
  //arrys containting the coordinates for different movement patterns (mp)
  public static int [,] plant_day2_mp ={{0,1},
                                        {0,-1},
                                        {1,0},
                                        {-1,0}};


}
