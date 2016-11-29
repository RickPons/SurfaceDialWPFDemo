using System;
using Windows.UI.Input;

namespace SurfaceDialExample.Interfaces
{
    [System.Runtime.InteropServices.Guid("1B0535C9-57AD-45C1-9D79-AD5C34360513")]

    [System.Runtime.InteropServices.InterfaceType(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable)]

    interface IRadialControllerInterop

    {

        RadialController CreateForWindow(

        IntPtr hwnd,

        [System.Runtime.InteropServices.In]ref Guid riid);

    }
}
