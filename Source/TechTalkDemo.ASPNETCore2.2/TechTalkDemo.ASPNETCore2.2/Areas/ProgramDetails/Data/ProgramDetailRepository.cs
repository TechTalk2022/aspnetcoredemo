using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechtalkDemo.DBEngine;
using TechTalkDemo.ASPNETCore2._2.Areas.ProgramDetails.Models;

namespace TechTalkDemo.ASPNETCore2._2.Areas.ProgramDetails.Data
{
    public interface IProgramDetailRepository
    {

        DataTable GetProgramDetails();
        void SaveProgramInfo(ProgramDetail objModel);
        DataTable GetProgramInfoById(int sSId);
        void DeleteProgramInfo(int sSId);

    }
    public class ProgramDetailRepository : IProgramDetailRepository
    {


        private readonly ISqlDBConnection _sqlDBConnection;

        public ProgramDetailRepository(ISqlDBConnection sqlDBConnection)
        {
            _sqlDBConnection = sqlDBConnection;
        }



        public void DeleteProgramInfo(int sSId)
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = {
                new SqlParameter("@ProgramId", sSId),
                new SqlParameter("@ActionId", 3)
            };
            _sqlDBConnection.ExecuteNonQuery("ProgramDetails_CURD", CommandType.StoredProcedure, param);
        }

        public DataTable GetProgramDetails()
        {
            DataTable dt = new DataTable();
            dt = _sqlDBConnection.ExecuteTable("ProgramDetails_CURD", CommandType.StoredProcedure);
            return dt;

        }

        public DataTable GetProgramInfoById(int sSId)
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = {
                new SqlParameter("@ProgramId", sSId),
                new SqlParameter("@ActionId", 4)
            };


            dt = _sqlDBConnection.ExecuteTable("ProgramDetails_CURD", CommandType.StoredProcedure, param);
            return dt;
        }

        public void SaveProgramInfo(ProgramDetail objModel)
        {


            SqlParameter[] param = {
                                    new SqlParameter("@ActionId",(objModel.ProgramId==0?1:2) ),
                                    new SqlParameter("@ProgramId",objModel.ProgramId ),
                                    new SqlParameter("@StartYear",objModel.StartYear),
                                    new SqlParameter("@ProgramCode",objModel.ProgramCode),
                                    new SqlParameter("@ProgramName", objModel.ProgramName),
                                    new SqlParameter("@ProgramDesc",objModel.ProgramDesc),
                                    new SqlParameter("@Duration",objModel.Duration),
                                    new SqlParameter("@ProgramType",objModel.ProgramType)
                                    };


            _sqlDBConnection.ExecuteNonQuery("ProgramDetails_CURD", CommandType.StoredProcedure, param);
        }
    }
}
