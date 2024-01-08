using System;

namespace BTMM.Common.Settings;

public class LayoutData : ICloneable
{
    public double ContentHeight;

    public double BottomHeight;

    public double LeftContentWidth;

    public double RightContentWidth;

    public LayoutData? Copy() => Clone() as LayoutData;

    public object Clone() => new LayoutData();
}
