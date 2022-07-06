using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using PanoramaControl;
using System.Windows.Data;
using System.Windows.Threading;

namespace WpfApplication1
{
    public class MainWindowViewModel : INPCBase
    {
        private Random rand = new Random(DateTime.Now.Millisecond);
        private List<DummyTileData> dummyData = new List<DummyTileData>();
        private IMessageBoxService messageBoxService;



        public MainWindowViewModel(IMessageBoxService messageBoxService)
        {
            this.messageBoxService = messageBoxService;

            //create some dummy data
            dummyData.Add(new DummyTileData("Add", @"Images/Add.png"));
            dummyData.Add(new DummyTileData("Adobe", @"Images/Adobe.png"));
            dummyData.Add(new DummyTileData("Android", @"Images/Android.png"));
            dummyData.Add(new DummyTileData("Author", @"Images/Author.png"));
            dummyData.Add(new DummyTileData("Blogger", @"Images/Blogger.png"));
            dummyData.Add(new DummyTileData("Copy", @"Images/Copy.png"));
            dummyData.Add(new DummyTileData("Delete", @"Images/Delete.png"));
            dummyData.Add(new DummyTileData("Digg", @"Images/Digg.png"));
            dummyData.Add(new DummyTileData("Edit", @"Images/Edit.png"));
            dummyData.Add(new DummyTileData("Facebook", @"Images/Facebook.png"));
            dummyData.Add(new DummyTileData("GMail", @"Images/GMail.png"));
            dummyData.Add(new DummyTileData("RSS", @"Images/RSS.png"));
            dummyData.Add(new DummyTileData("Save", @"Images/Save.png"));
            dummyData.Add(new DummyTileData("Search", @"Images/Search.png"));
            dummyData.Add(new DummyTileData("Trash", @"Images/Trash.png"));
            dummyData.Add(new DummyTileData("Twitter", @"Images/Twitter.png"));
            dummyData.Add(new DummyTileData("VisualStudio", @"Images/VisualStudio.png"));
            dummyData.Add(new DummyTileData("Wordpress", @"Images/Wordpress.png"));
            dummyData.Add(new DummyTileData("Yahoo", @"Images/Yahoo.png"));
            dummyData.Add(new DummyTileData("YouTube", @"Images/YouTube.png"));

            //Great some dummy groups
            List<PanoramaGroup> data = new List<PanoramaGroup>();
            List<IPanoramaTile> tiles = new List<IPanoramaTile>();

            for (int i = 0; i < 4; i++)
            {
                tiles.Add(CreateTile(true));
				tiles.Add(CreateTile(true));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(true));

				tiles.Add(CreateTile(true));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));

				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));

				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
            }

			data.Add(new PanoramaGroup("Settings", CollectionViewSource.GetDefaultView(tiles)));

			tiles = new List<IPanoramaTile>();

			for (int i = 0; i < 4; i++)
			{
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(true));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(true));

				tiles.Add(CreateTile(true));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(true));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));

				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));

				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
				tiles.Add(CreateTile(false));
			}

			data.Add(new PanoramaGroup("Settings 2", CollectionViewSource.GetDefaultView(tiles)));

            PanoramaItems = data;

        }


        private PanoramaTileViewModel CreateTile(bool isDoubleWidth)
        {
            DummyTileData dummyTileData = dummyData[rand.Next(dummyData.Count)];
            return new PanoramaTileViewModel(messageBoxService, 
                dummyTileData.Text, dummyTileData.ImageUrl, isDoubleWidth);
        }


        private IEnumerable<PanoramaGroup> panoramaItems;

        public IEnumerable<PanoramaGroup> PanoramaItems
        {
            get { return this.panoramaItems; }

            set
            {
                if (value != this.panoramaItems)
                {
                    this.panoramaItems = value;
                    NotifyPropertyChanged("CompanyName");
                }
            }
        }
    }




    public class DummyTileData
    {
        public string Text { get; private set; }
        public string ImageUrl { get; private set; }

        public DummyTileData(string text, string imageUrl)
        {
            this.Text = text;
            this.ImageUrl = imageUrl;
        }
    }
}
