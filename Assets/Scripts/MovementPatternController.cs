using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CharacterMover;

public class MovementPatternController: MonoBehaviour
{
  CharacterMover mover;
  public Vector3Int startPosition;
    // Start is called before the first frame update
    void Start()
    {
      mover = gameObject.AddComponent(typeof(CharacterMover)) as CharacterMover;
      mover.setPosition(startPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
