using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;
using System.Windows.Media;
using Stats_Monitoring.Infrastructure;
using Stats_Monitoring.ViewModel;

namespace Stats_Monitoring
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        private bool isDragging;
        private UIElement draggedItem;
        private Point startPoint;
        private Border dragAdorner;

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
