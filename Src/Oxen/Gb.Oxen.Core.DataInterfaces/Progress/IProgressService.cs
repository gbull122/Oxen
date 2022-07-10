namespace Gb.Oxen.Core.Interfaces.Progress;

using Gb.Oxen.Core.Interfaces.Data;
using System;
using System.Threading.Tasks;

internal interface IProgressService
{
    string Message { get; set; }
    bool ProgressIndeterminate { get; set; }
    int ProgressValue { get; set; }
    Task ExecuteAsync(Func<IProgress<string>, string, Task> task, string arg);
    Task ExecuteAsync(Func<IProgress<string>, string, string, Task> task, string arg1, string arg2);
    Task ExecuteAsync(Func<IProgress<string>, IDataSet, Task> task, IDataSet arg);
    Task ExecuteAsync(Task<bool> task, string v);
    Task ExecuteAsync(Func<IProgress<string>, double[,], int, Task> task, double[,] arg, int arg1);
    Task ContinueAsync(Task task, string v);
}
