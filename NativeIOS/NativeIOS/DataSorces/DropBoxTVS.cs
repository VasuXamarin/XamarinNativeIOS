using System;
using System.Collections.Generic;
using Foundation;
using NativeIOS.Model;
using UIKit;
using static NativeIOS.Model.DropBoxData;

namespace NativeIOS
{
    internal class DropBoxTVS : UITableViewSource
    {
        private List<DropBoxRow> data;

        public DropBoxTVS(List<DropBoxRow> data)
        {
            this.data = data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            var cell = (CustomCell)tableView.DequeueReusableCell("Cellid", indexPath);

            var dropBoxContent = data[indexPath.Row];

            cell.UpdateDropBoxData(dropBoxContent);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }
    }
}