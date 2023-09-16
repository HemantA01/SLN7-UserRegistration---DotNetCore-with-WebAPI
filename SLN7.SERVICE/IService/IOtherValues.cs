using SLN7.MODEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLN7.SERVICE.IService
{
    public interface IOtherValues
    {
        Task<List<SaveSampleVals1>> GetData();
        Task<bool> InsertData(List<SaveSampleVals1> vals1);
    }
}
