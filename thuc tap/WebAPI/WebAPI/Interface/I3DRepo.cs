using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Interface
{
    public interface I3DRepo
    {
        Task<_3D>GetByIDAsync(int id);
        Task<_3D>CreateAsync(_3D _3D);
        Task<_3D?>UpdateAsync(int id,_3D _3D);
        Task<_3D?>DeleteAsync(int id); 
    }
}