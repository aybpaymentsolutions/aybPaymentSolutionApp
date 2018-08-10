using System;
using System.Collections.Generic;
using System.Text;

namespace aybPaymentSolutionApp.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
