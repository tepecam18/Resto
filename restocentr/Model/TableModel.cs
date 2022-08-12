namespace restocentr.Model
{
    public class TableModel
    {
        public string ID { get; set; }
        public string? TableName { get; set; }
        public string Floor { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }

        #region Property
        public int CacheLeft { get; set; }
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