using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface ISingleRepo
    {
        Task<Model.Single>GetByIDAsync(int id);
        Task<Model.Single>CreateAsync(Model.Single Single);
        Task<Model.Single?>UpdateAsync(int id,Model.Single Single);
        Task<Model.Single?>DeleteAsync(int id); 
    }
}