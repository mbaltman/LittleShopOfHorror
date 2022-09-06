using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPatterns: MonoBehaviour
{
  //arrys containting the coordinates for different movement patterns (mp)

  public static int [,] diagonal_1 ={{1,1},
                                        {1,-1},
                                        {-1,1},
                                        {-1,-1}};

  public static int [,] diagonal_2 ={{2,2},
                                        {2,-2},
                                        {-2,2},
                                        {-2,-2}};

  public static int [,] adjacent_1 ={{0,1},
                                        {0,-1},
                                        {1,0},
                                        {-1,0}};
  public static int [,] adjacent_2 ={{0,2},
                                        {0,-2},
                                        {2,0},
                                        {-2,0}};

  //this causes the characters to occassionaly stay on the same square
  public static int [,] characters = {{0,0},{0,0}};
}
