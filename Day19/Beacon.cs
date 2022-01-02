using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19;

public class Beacon
{
    private int _rx;
    private int _ry;
    private int _rz;
    public Beacon(int rx, int ry, int rz)
    {
        _rx = rx;
        _ry = ry;
        _rz = rz;
    }

    // -2,-3,1   (x,y,z)     5,6,-4
    //  2,-1,3   (-x,-z,-y) -5,4,-6
    // -1,-3,-2  (-z,y,x)    4,6,5
    //  1,3,-2   (z,-y,x)   -4,-6,5
    //  3,1,2    (-y,z,-x)  -6,-4,-5



}

