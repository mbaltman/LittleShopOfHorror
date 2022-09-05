using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPatterns: MonoBehaviour
{
  public static int [,] diagonal_1 ={{1,1},
                                        {1,-1},
                                        {-1,1},
                                        {-1,-1}};
  //arrys containting the coordinates for different movement patterns (mp)
  public static int [,] adjacent_1 ={{0,1},
                                        {0,-1},
                                        {1,0},
                                        {-1,0}};
}
