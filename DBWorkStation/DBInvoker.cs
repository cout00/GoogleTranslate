using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;

namespace DBWorkStation
{
    public class DBInvoker
    {
        bdWordsEntities db;

        public DBInvoker()
        {            
            db = new bdWordsEntities();
            db.Word.Load();
        }


        public List<Word> GetWords()
        {
            return db.Word.Select(a => a).ToList();
        } 



    }
}
