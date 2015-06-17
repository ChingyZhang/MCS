﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Infrastructure
{
    public interface IDictionary_Column
    {
        Common.Result.Result<bool, string> AddDictionary_Column(Chingy_SYS.DAL.DB.Dictionary_Column Dictionary_Column);
        Common.Result.Result<bool, string> DestroyDictionary_Column(int ID);
        Common.Result.Result<bool, System.Collections.Generic.IList<Chingy_SYS.DAL.DB.Dictionary_Column>> GetDicColByTableCode(string TableCode);
        System.Collections.Generic.IList<Chingy_SYS.DAL.DB.Dictionary_Column> GetDicList();
        Common.Result.Result<bool, string> ModifyDictionary_Column(Chingy_SYS.DAL.DB.Dictionary_Column Dictionary_Column);
    }
}