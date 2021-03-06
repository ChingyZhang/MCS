﻿using Chingy_SYS.BLL.Infrastructure;
using Chingy_SYS.DAL.DB;
using Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chingy_SYS.BLL.Service
{
    public class UD_TableListService : IUD_TableService
    {
        Chingy_SYS.DAL.DAO.UD_TableDAO TableDAO = new DAL.DAO.UD_TableDAO();

        public Result<IDictionary<string, int>, IList<UD_TableList>> GetTableList(Guid? id, int? rows, int? page)
        {
            return TableDAO.GetList(id, rows, page);
        }


        public Result<bool, string> Create(Chingy_SYS.DAL.DB.UD_TableList model)
        {
            return TableDAO.Create(model);
        }

        public Result<bool, string> Delete(Chingy_SYS.DAL.DB.UD_TableList UD_TableList)
        {
            return TableDAO.Delete(UD_TableList);
        }


        public Result<bool, string> DestroyTable(Guid Guid)
        {
            return TableDAO.DestroyTable(Guid);
        }

        public Result<bool, string> Edit(Chingy_SYS.DAL.DB.UD_TableList model)
        {
            return TableDAO.Edit(model);
        }


        public Result<bool, string> RemoveField(Guid Guid)
        {
            return TableDAO.RemoveField(Guid);
        }

        public Result<bool, string> EditField(UD_ModelFields UD_ModelFields)
        {
            return TableDAO.EditField(UD_ModelFields);
        }

        public Result<Guid, string> CreateField(UD_ModelFields UD_ModelFields)
        {
            return TableDAO.CreateField(UD_ModelFields);
        }

        public Result<bool, string> Create(UD_Panel model)
        {
            throw new NotImplementedException();
        }

        public Result<bool, string> Delete(UD_Panel model)
        {
            throw new NotImplementedException();
        }

        public Result<bool, string> Edit(UD_Panel model)
        {
            throw new NotImplementedException();
        }

        public Result<IDictionary<string, int>, IList<UD_Panel>> GetList(Guid? id, int? rows, int? page)
        {
            throw new NotImplementedException();
        }
    }
}
