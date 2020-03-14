using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Data;

namespace Basica
{
    public abstract class CID<T> : IAbstractABM<T>, IImage,IJSON
    {
        public int Id { get; set; }
        public HttpPostedFile FU { get; set; }
        public string Directory { get; set; }
        public string Prefix { get; set; }

        public string Path {
            get { return AppDomain.CurrentDomain.BaseDirectory+ "imagenes\\" + this.Directory + "\\" + this.Prefix + this.Id + ".jpg"; }
        }

        public string URL {
            get {
                InitPrefix();
                if(File.Exists(Path))
                {
                    return "imagenes/"+this.Directory + "/" + this.Prefix + this.Id + ".jpg";
                }
                ChangePrefix();
                if (File.Exists(Path))
                {
                    return "imagenes/"+this.Directory + "/" + this.Prefix + this.Id + ".jpg";
                }
                InitPrefix();
                return "imagenes/"+this.Directory + "/" + this.Prefix + "default.jpg";
            }
        }

        #region MétodosAbstractos
        public abstract void Add();

        public void ChangePrefix()
        {
            if (this.Prefix.EndsWith("_"))
            {
                this.Prefix = this.Prefix.Remove(this.Prefix.Length - 1);
                return;
            }
            this.Prefix += "_";
        }

        public void DeleteImage()
        {
            InitPrefix();
            if (File.Exists(Path))
            {
                File.Delete(Path);
                ChangePrefix();
                return;
            }
            ChangePrefix();
            if (File.Exists(Path))
            {
                File.Delete(Path);
                ChangePrefix();
                return;
            }

            InitPrefix();
        }

        public abstract void Erase();

        public abstract string Find();

        public void InitPrefix()
        {
            if (this.Prefix.EndsWith("_"))
            {
                ChangePrefix();
            }
        }

        public abstract List<T> List();
        public abstract void Modify();

        public string RowToJSON(DataRow T)
        {
            string JSON = "{";
            for (int i = 0; i < T.Table.Columns.Count; i++)
            {
                JSON += "\"" + T.Table.Columns[i].ColumnName + "\":\"" + T[i] + "\",";
                if (this.Prefix != "")
                {
                    int aux = this.Id;
                    this.Id = int.Parse(T["id"].ToString());
                    JSON += "\"URL\":\"" + this.URL + "\",";
                    this.Id = aux;
                }
            }
            JSON = JSON.Remove(JSON.Length - 1) + "}";
            return JSON;
        }

        public void SaveImage()
        {
            if(this.FU == null) { return; }
            if (this.FU.FileName == "") { return; }
            this.DeleteImage();
            this.FU.SaveAs(Path);
        }

        public string TableToJSON(DataTable T)
        {
            string JSON = "[";
            if (T.Rows.Count == 0)
            {
                return JSON += "]";
            }
            foreach (DataRow DR in T.Rows)
            {
                JSON += RowToJSON(DR)+",";
            }
            JSON = JSON.Remove(JSON.Length - 1) + "]";
            return JSON;
        }


        #endregion
    }
}
