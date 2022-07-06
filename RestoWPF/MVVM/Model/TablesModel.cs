using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class TablesModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string? TableName { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }

        [Ignored]
        public int CacheLeft { get; set; }
        [Ignored]
        public int CacheTop { get; set; }

        public TablesModel()
        {
            CacheLeft = Left;
            CacheTop = Top;
        }

        public bool Save
        {
            set
            {
                if (value)
                {
                    Left = CacheLeft;
                    Top = CacheTop;
                }
            }
        }

        public bool reject
        {
            set
            {
                if (value)
                {
                    CacheLeft = Left;
                    CacheTop = Top;
                }
            }
        }
    }
}