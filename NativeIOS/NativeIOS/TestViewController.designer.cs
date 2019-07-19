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
    [Register ("TestViewController")]
    partial class TestViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView CView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CView != null) {
                CView.Dispose ();
                CView = null;
            }
        }
    }
}