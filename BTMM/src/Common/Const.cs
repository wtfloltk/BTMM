using Avalonia.Input;
using BTMM.Common.Defines;

namespace BTMM.Common;

public class Const
{
    public static Cursor LinkCursor { get; } = new(StandardCursorType.Hand);

    public static readonly Size DefaultWindowSize = new Size(900, 520);
}
