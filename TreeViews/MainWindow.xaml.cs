using System.Collections.Generic;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace TreeViews
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive
                };

                item.Items.Add(null);

                item.Expanded += ExpandedFolder;

                folderView.Items.Add(item);
            }
        }

        private void ExpandedFolder(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            //Remove empty items.
            item.Items.Clear();

            var path = (string)item.Tag;

            var dis = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(path);
                if (dirs.Length > 0)
                    dis.AddRange(dirs);
            }
            catch(Exception ex)  { Console.WriteLine(ex.Message); }

            dis.ForEach(x =>  
            {
                var subItem = new TreeViewItem()
                {
                    Header = getFolderName(x),
                    Tag = x
                };

                subItem.Items.Add(null);

                subItem.Expanded += ExpandedFolder;

                item.Items.Add(subItem);
            });
        }

        public static string getFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            path = path.Replace('/', '\\');

            if (path.LastIndexOf('\\') < 0)
                return string.Empty;

            return path.Substring(path.LastIndexOf('\\')+1);
        }
    }
}
