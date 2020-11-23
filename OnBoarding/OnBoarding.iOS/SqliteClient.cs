using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

using SQLite;
using OnBoarding.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]

namespace OnBoarding.Droid

{
    public class SqliteClient : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            //Se crea la base de datos
            var path = Path.Combine(documentPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);

        }


    }
}