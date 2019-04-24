using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBREnemies
{
    public enum EnemyState
    {
        IDEL,
        ATTACK,
        PATROL,
        DEAD
    };

    [Serializable]
    public class FallSpeed
    {
        public float Min = 0f;
        public float Max = 0f;

        public float Clamp(float speed)
        {
            if (speed < Min) return Min;
            else if (speed > Max) return Max;
            return speed;
        }
    };
}
