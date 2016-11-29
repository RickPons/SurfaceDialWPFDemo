using SurfaceDialExample.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Storage.Streams;
using Windows.UI.Input;
using SurfaceDialExample.Extensions;


namespace SurfaceDialExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RadialController controller = null;
        int mainClicks ;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StarController();
        }

        private void StarController()
        {
            var interop = (IRadialControllerInterop)System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal
                .GetActivationFactory(typeof(RadialController));

            Guid guid = typeof(RadialController).GetInterface("IRadialController").GUID;

            Window window = Window.GetWindow(this);
            var wih = new WindowInteropHelper(window);
            IntPtr hWnd = wih.Handle;

            controller = interop.CreateForWindow(hWnd, ref guid);
            controller.ControlAcquired += Controller_ControlAcquired;
            controller.ControlLost += Controller_ControlLost;
            controller.RotationChanged += Controller_RotationChanged;
            controller.ButtonClicked += Controller_ButtonClicked;
            
            controller.RotationResolutionInDegrees = 1;
            var button = RadialControllerMenuItem.CreateFromKnownIcon("Item 1", RadialControllerMenuKnownIcon.Ruler);
           
            var button2 = RadialControllerMenuItem.CreateFromKnownIcon("Item 2", RadialControllerMenuKnownIcon.PenType);
            button.Invoked += Button_Invoked;
            button2.Invoked += Button_Invoked;
            controller.Menu.Items.Add(button);
            controller.Menu.Items.Add(button2);
            mainClicks = 0;
            
        }

        private void Button_Invoked(RadialControllerMenuItem sender, object args)
        {
            switch (sender.DisplayText)
            {
                case "Item 1":
                    txtButtonName.Text = "You clicked Item 1 button";
                    break;

                case "Item 2":
                    txtButtonName.Text = "You clicked Item 2 button";
                    break;

                default:
                    break;
            }
        }

        private void Controller_ControlLost(RadialController sender, object args)
        {
            txtStatus.Text = "Device lost";
        }

        private void Controller_ControlAcquired(RadialController sender, RadialControllerControlAcquiredEventArgs args)
        {
            txtStatus.Text = "Device Acquired";
        }

        private void Controller_RotationChanged(RadialController sender, RadialControllerRotationChangedEventArgs args)
        {
            rotateTransform.Angle = rotateTransform.Angle+= args.RotationDeltaInDegrees;
            txtRotation.Text = args.RotationDeltaInDegrees.ToString();
        }

        private void Controller_ButtonClicked(RadialController sender, RadialControllerButtonClickedEventArgs args)
        {
            txtMainbtn.Text = string.Format("Main button clicked {0} times", mainClicks++);
        }

        
    }
}
