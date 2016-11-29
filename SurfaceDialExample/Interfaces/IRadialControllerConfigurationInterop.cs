using System;
using Windows.UI.Input;

namespace SurfaceDialExample.Interfaces
{
    [System.Runtime.InteropServices.Guid("787cdaac-3186-476d-87e4-b9374a7b9970")]

    [System.Runtime.InteropServices.InterfaceType(System.Runtime.InteropServices.ComInterfaceType.InterfaceIsIInspectable)]

    interface IRadialControllerConfigurationInterop

    {

        RadialControllerConfiguration GetForWindow(

        IntPtr hwnd,

        [System.Runtime.InteropServices.In]ref Guid riid);

    }
}
