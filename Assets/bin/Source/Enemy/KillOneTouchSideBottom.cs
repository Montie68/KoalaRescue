using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InfiniteRunnerEngine;

namespace Enemies {
    public class KillOneTouchSideBottom : KillsPlayerOnTouch
    {

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            BoxCollider2D boxCollider = this.GetComponent<BoxCollider2D>();
           // if (boxCollider.)
        }
    }
}
