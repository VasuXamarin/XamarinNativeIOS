// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NativeIOS
{
    [Register ("CustomCell")]
    partial class CustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Imageview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Imageview != null) {
                Imageview.Dispose ();
                Imageview = null;
            }

            if (LblDescription != null) {
                LblDescription.Dispose ();
                LblDescription = null;
            }

            if (LblTitle != null) {
                LblTitle.Dispose ();
                LblTitle = null;
            }
        }
    }
}