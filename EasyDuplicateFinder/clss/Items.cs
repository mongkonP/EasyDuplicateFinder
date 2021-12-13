using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasyDuplicateFinder.clss
{
   /*public  class Item
    {
        string FileName, FullPath, FileSize, FileMD5;
        public Item(string _FileName, string _FullPath, string _FileSize, string _FileMD5)
        {
            FileName = _FileName;FileMD5 = _FileMD5;FullPath = _FullPath;FileSize = _FileSize;
        }
    }*/
    public class Items
    {
       // List<Item> items;
         DataTable _DataItems;
        public Items()
        {
            //  items = new List<Item>();
            _DataItems = new DataTable();
            _DataItems.Columns.Add(new DataColumn("selected", typeof(bool )));
            _DataItems.Columns.Add(new DataColumn("FileName", typeof(string)));
            _DataItems.Columns.Add(new DataColumn("FullPath", typeof(string)));
            _DataItems.Columns.Add(new DataColumn("FileSize", typeof(string)));
            _DataItems.Columns.Add(new DataColumn("Date Modified", typeof(string)));
            _DataItems.Columns.Add(new DataColumn("FileMD5", typeof(string)));
        }
        public void Add(string path)
        {

            DataRow dr = _DataItems.NewRow();

            dr["selected"] = false;
            dr["FileName"] = Path.GetFileName(path);
            dr["FullPath"] = path;
            dr["FileSize"] =new  FileInfo(path).Length;
            dr["Date Modified"] = File.GetLastWriteTime(path);
            dr["FileMD5"] = "";//Ext.CalculateMD5(path);
            System.Threading.Thread.Sleep(100);
            _DataItems.Rows.Add(dr);
        }
        public DataTable DataItems
        {
            get {
                 DataTable dst = _DataItems.Clone();
                /*foreach (DataRow thisRow in dst.Select("select *  having count(FileMD5) >='2'","FileMD5 ASC"))
                {
                    dst.ImportRow(thisRow);
                }
                return dst; */
                System.Windows.Forms.MessageBox.Show(_DataItems.Rows.Count.ToString());
                return _DataItems;
            
            }
        }
    }
}
