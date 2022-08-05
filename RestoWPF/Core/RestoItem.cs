using System;

namespace RestoWPF.Core
{
    public class RestoItem : ViewModelBase
    {
        private readonly Type _contentType;
        //private readonly object? _dataContext;

        private object? _content;
        public bool IsCache { get; set; }


        public RestoItem(Type contentType)
        {
            _contentType = contentType;
        }

        public object? Content
        {
            get
            {
                if (_content is not null && IsCache)
                {
                    return _content;
                }
                return _content = CreateContent();
            }
        }

        private object? CreateContent()
        {
            var content = Activator.CreateInstance(_contentType);
            //if (_dataContext != null && content is FrameworkElement element)
            //{
            //    element.DataContext = _dataContext;
            //}
            return content;
        }
    }
}
