namespace Gb.Oxen.App.Docking
{
    using AvalonDock;
    using AvalonDock.Controls;
    using AvalonDock.Layout;
    using Gb.Oxen.Core.Interfaces.Docking;
    using Prism.Regions;
    using Prism.Regions.Behaviors;
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Windows;

    public class DockingBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        private DockingManager dockingManager;

        public static readonly string BehaviorKey = "DockingManagerBehavior";

        public DependencyObject HostControl
        {
            get
            {
                return dockingManager;
            }

            set
            {
                dockingManager = value as DockingManager;

            }
        }

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViewsCollectionChanged;
            Region.Views.CollectionChanged += ViewsCollectionChanged;
            dockingManager.DocumentClosed += DockingManager_DocumentClosed;
        }

        private void DockingManager_DocumentClosed(object? sender, DocumentClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ActiveViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        private void ViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (object newItem in e.NewItems)
                {
                    var test = GetDataContext(newItem);
                    if (test == null)
                        return;

                    var dockControl = (IDockControl)GetDataContext(newItem) as IDockControl;

                    if (dockControl.Position == DockingLocation.Document)
                    {
                        var document = new LayoutAnchorable
                        {
                            CanClose = true,
                            CanAutoHide = false
                        };

                        document.Content = newItem;

                        var documentPanel = dockingManager.FindName("DocumentPanel") as LayoutDocumentPane;

                        documentPanel.Children.Add(document);
                        document.IsActive = true;
                        return;
                    }


                    if (dockControl.Position == DockingLocation.ControlPanel)
                    {

                        var anchorablePanel = new LayoutAnchorable();
                        anchorablePanel.Content = newItem;
                        anchorablePanel.CanClose = false;

                        var controlPanel = dockingManager.FindName("ControlPanel") as LayoutAnchorablePane;
                        controlPanel.Children.Add(anchorablePanel);

                        var debug = controlPanel.IsVisible;
                        return;
                    }

                    //var statusPanel = dockingManager.FindName("LowerPanel") as LayoutAnchorablePane;
                    //statusPanel.Children.Add(anchorablePanel);
                }
            }
        }

        private object GetDataContext(object item)
        {
            var frameworkElement = item as FrameworkElement;
            return frameworkElement == null ? item : frameworkElement.DataContext;
        }
    }
}
