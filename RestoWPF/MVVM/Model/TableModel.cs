using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoWPF.MVVM.Model
{
    public class TableModel : RealmObject
    {
        [PrimaryKey]
        public ObjectId ID { get; set; } = ObjectId.GenerateNewId();
        public string? TableName { get; set; }
        public string Floor { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }

        #region Property
        [Ignored]
        public int CacheLeft { get; set; }
        [Ignored]
        public int CacheTop { get; set; }

        public TableModel()
        {
            CacheLeft = Left;
            CacheTop = Top;
        }
        #endregion

        #region Methods
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
        #endregion

    }
}