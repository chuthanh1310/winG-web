using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Dto.threeD;
using WebAPI.Model;

namespace WebAPI.Mapper
{
    public static class Mapper3D
    {
        public static threedDto To3DDto(this _3D _3DModel){
            return new threedDto{
                ID=_3DModel._3DID,
                Name=_3DModel.Name,
                ProductID=_3DModel.ProductID
            };
        }
        public static _3D ToAdd(this Create3dDto create3DDto,int ProductID){
            return new _3D{
                Name=create3DDto.Name,
                ProductID=ProductID
            };
        }
    }
}