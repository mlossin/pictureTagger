using Dapper;
using PictureTagger.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureTagger.DataAccess.Sqlite
{
    public static class DataAccess
    {
        public static string GetConnectionString(string csName = "PictureTagSqlite") {
            var cs = System.Configuration.ConfigurationManager.ConnectionStrings[csName].ToString();
            return cs;
        }

        #region "picture"
        public static IEnumerable<Picture> PictureGet(int Id = 0)
        {
            string sql = "select Id,Path,Filename,Fileextension from Picture";
            if (Id > 0)
            {
                sql = "select Id,Path,Filename,Fileextension from Picture where Id=@Id";
            }
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                var output = con.Query<Picture>(sql,Id);
                return output;
            }
        }

        public static void PictureSave(Picture item)
        {
            if (item != null)
            {
                if (item.Id > 0)
                {
                    //Update
                    using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
                    {
                        var output = con.Execute("update Picture set Path=@Path, Filename=@Filename, Fileextension=@Fileextension where Id = @Id", item);
                    }
                }
                else if (item.Id < 0)
                {
                    //Delete
                    //using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
                    //{
                    //    con.Query<Picture>
                    //}
                }
                else
                {
                    // New = 0
                    using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
                    {
                        var output = con.Execute("insert into Picture (Path,Filename,Fileextension) values (@Path,@Filename,@Fileextension)", item);
                    }
                } 
            }

        }
        #endregion

        #region "Tags"

        public static IEnumerable<SearchTag> TagGet(int Id = 0)
        {
            string sql = "select Id,Name from SearchTag";
            if (Id > 0)
            {
                sql = "select Id,Name from SearchTag where Id=@Id";
            }
            using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
            {
                var output = con.Query<SearchTag>(sql, Id);
                return output;
            }
        }

        public static void TagSave(SearchTag item)
        {
            if (item != null)
            {
                //only new
                using (IDbConnection con = new SQLiteConnection(GetConnectionString()))
                {
                    con.Execute("insert into SearchTag (Name) values (@Name)", item);
                }
            }
        }
        #endregion


    }
}
