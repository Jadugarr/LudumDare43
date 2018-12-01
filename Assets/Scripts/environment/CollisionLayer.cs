using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This Enum represents the Collision layer masks.
 */
public enum CollisionLayer : int
{
    Default = 1,
    TransparentFx = 1 << 1,
    IgnoreRaycast = 1 << 2,
    Water = 1 << 4,
    UI = 1 << 5,
    Environment = 1 << 8,
    EnvironmentChecker = 1 << 9,
    Hitbox = 1 << 10
}
