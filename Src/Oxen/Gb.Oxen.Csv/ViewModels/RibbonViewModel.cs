namespace Gb.Oxen.Csv.ViewModels;

using Gb.Oxen.Core.Interfaces.Services;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.IO;

public class RibbonViewModel : BindableBase
{
    private readonly IDataService dataService;
    private readonly IDialogService dialogService;

    public DelegateCommand LoadCommand { get; private set; }
    public DelegateCommand SaveCommand { get; private set; }

    public RibbonViewModel(IDataService dataService, IDialogService dialogService)
    {
        this.dataService = dataService;
        this.dialogService = dialogService;

        LoadCommand = new DelegateCommand(Load);
        SaveCommand = new DelegateCommand(Save);
    }

    private void Save()
    {
        throw new NotImplementedException();
    }

    private void Load()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Csv files (*.csv)|*.csv";
        if (openFileDialog.ShowDialog() == true)
        {
            var dataSetName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

            if (dataService.DatasetNameExists(dataSetName))
            {
                var dialogParameters = new DialogParameters()
                    {
                        { "title", "Duplicate Data" },
                         { "message", string.Format("There is already a DataSet called {0}. Rename the csv file and try again.",dataSetName) }
                    };

                void Callback(IDialogResult result)
{
}

                dialogService.ShowDialog("NotificationDialogView", dialogParameters, Callback);
                return;
            }

            //await progressService.ExecuteAsync(LoadCsvFile, openFileDialog.FileName, dataSetName);
        }
    }
}
