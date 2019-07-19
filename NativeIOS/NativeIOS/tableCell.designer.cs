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
    [Register ("tableCell")]
    partial class tableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DecriptionLbl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Imageview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLbl { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DecriptionLbl != null) {
                DecriptionLbl.Dispose ();
                DecriptionLbl = null;
            }

            if (Imageview != null) {
                Imageview.Dispose ();
                Imageview = null;
            }

            if (TitleLbl != null) {
                TitleLbl.Dispose ();
                TitleLbl = null;
            }
        }
    }
}