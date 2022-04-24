using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public interface ITankSetup
{
    CannonObject Cannon { get; set; }
    BodyObject Body { get; set; }
    TowerObject Tower { get; set; }
}
