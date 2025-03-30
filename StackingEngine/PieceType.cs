using System.Collections.Generic;

namespace StackingEngine
{
    public class PieceType
    {
        public string Name { get; set;  }
        public Dictionary<Orientation, Pos[]> Rotations { get; set; }
        public Dictionary<(Orientation, Orientation), Pos[]> KickTable { get; set;  }
    }
}
