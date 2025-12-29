using Entities.GPMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GPMS
{
    public class FetchManager : DbBase
    {
        public FetchDto SkipNGetN_OfCustomerDataWithSearch(int pCompanyID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            FetchDto resFetchDto = new FetchDto();
            resFetchDto.DtoStatus = DtoStatus.Failed;
            try
            {
                var _pCompanyID = new SqlParameter
                {
                    ParameterName = "@pCompanyID",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = pCompanyID
                };
                var _pIsActive = new SqlParameter
                {
                    ParameterName = "@pIsActive",
                    SqlDbType = SqlDbType.Bit,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pIsActive == null ? (object)DBNull.Value : pIsActive.Value)
                };
                var _pSearchTxt = new SqlParameter
                {
                    ParameterName = "@pSearchTxt",
                    SqlDbType = SqlDbType.VarChar,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pSearchTxt == null ? (object)DBNull.Value : pSearchTxt)
                };
                var _pSkipNo = new SqlParameter
                {
                    ParameterName = "@pSkipNo",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = false,
                    Direction = ParameterDirection.Input,
                    Value = pSkipNo
                };
                var _pTakeNo = new SqlParameter
                {
                    ParameterName = "@pTakeNo",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pTakeNo == null ? (object)DBNull.Value : pTakeNo.Value) 
                };
                var _pTotalCount = new SqlParameter
                {
                    ParameterName = "@pTotalCount",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };
                var _pActivityInfo = new SqlParameter
                {
                    ParameterName = "@pActivityInfo",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 500,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };
                var _pIsSucceeded = new SqlParameter
                {
                    ParameterName = "@pIsSucceeded",
                    SqlDbType = SqlDbType.Bit,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };



                resFetchDto.CustomerInfoCollection = EntitiesContext.Database.SqlQuery<CustomerInfoBo>("EXEC [dbo].[proc_FetchCustomers]  @pCompanyID, @pIsActive, @pSearchTxt, @pSkipNo, @pTakeNo, @pTotalCount out, @pActivityInfo out , @pIsSucceeded out ", _pCompanyID, _pIsActive, _pSearchTxt, _pSkipNo, _pTakeNo, _pTotalCount , _pActivityInfo , _pIsSucceeded ).ToList();

                if (Convert.ToBoolean(_pIsSucceeded.Value))
                {
                    if (resFetchDto.CustomerInfoCollection != null && resFetchDto.CustomerInfoCollection.Count() > 0)
                    {
                        resFetchDto.SelectedCount = resFetchDto.CustomerInfoCollection.Count();
                        resFetchDto.TotalCount = (int)_pTotalCount.Value;
                        resFetchDto.DtoStatusNotes = new DtoStatusNotes();
                        resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                        resFetchDto.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        resFetchDto.DtoStatus = DtoStatus.NoDataFound;
                        resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                    }
                }
                else
                {
                    resFetchDto.DtoStatus = DtoStatus.Error;
                    resFetchDto.DtoStatusNotes.Exception = _pActivityInfo.Value.ToString();
                    resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());

                }
            }
            catch (Exception ex)
            {
                resFetchDto.DtoStatus = DtoStatus.Error;
                resFetchDto.DtoStatusNotes.Exception = ex.Message;
                resFetchDto.DtoStatusNotes.ExtraNotes.Add(ex.Message);
            }
            return resFetchDto;
        }
        public FetchDto SkipNGetN_OfStyleDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            FetchDto resFetchDto = new FetchDto();
            resFetchDto.DtoStatus = DtoStatus.Failed;
            try
            {
                var _pCustomerID = new SqlParameter
                {
                    ParameterName = "@pCustomerID",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = pCustomerID
                };
                var _pIsActive = new SqlParameter
                {
                    ParameterName = "@pIsActive",
                    SqlDbType = SqlDbType.Bit,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pIsActive == null ? (object)DBNull.Value : pIsActive.Value)
                };
                var _pSearchTxt = new SqlParameter
                {
                    ParameterName = "@pSearchTxt",
                    SqlDbType = SqlDbType.VarChar,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pSearchTxt == null ? (object)DBNull.Value : pSearchTxt)
                };
                var _pSkipNo = new SqlParameter
                {
                    ParameterName = "@pSkipNo",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = false,
                    Direction = ParameterDirection.Input,
                    Value = pSkipNo
                };
                var _pTakeNo = new SqlParameter
                {
                    ParameterName = "@pTakeNo",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pTakeNo == null ? (object)DBNull.Value : pTakeNo.Value)
                };
                var _pTotalCount = new SqlParameter
                {
                    ParameterName = "@pTotalCount",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };
                var _pActivityInfo = new SqlParameter
                {
                    ParameterName = "@pActivityInfo",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 500,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };
                var _pIsSucceeded = new SqlParameter
                {
                    ParameterName = "@pIsSucceeded",
                    SqlDbType = SqlDbType.Bit,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };



                resFetchDto.StyleInfoCollection = EntitiesContext.Database.SqlQuery<StyleInfoBo>("EXEC [dbo].[proc_FetchStyles]  @pCustomerID, @pIsActive, @pSearchTxt, @pSkipNo, @pTakeNo, @pTotalCount out, @pActivityInfo out , @pIsSucceeded out ", _pCustomerID, _pIsActive, _pSearchTxt, _pSkipNo, _pTakeNo, _pTotalCount, _pActivityInfo, _pIsSucceeded).ToList();

                if (Convert.ToBoolean(_pIsSucceeded.Value))
                {
                    if (resFetchDto.StyleInfoCollection != null && resFetchDto.StyleInfoCollection.Count() > 0)
                    {
                        resFetchDto.SelectedCount = resFetchDto.StyleInfoCollection.Count();
                        resFetchDto.TotalCount = (int)_pTotalCount.Value;
                        resFetchDto.DtoStatusNotes = new DtoStatusNotes();
                        resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                        resFetchDto.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        resFetchDto.DtoStatus = DtoStatus.NoDataFound;
                        resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                    }
                }
                else
                {
                    resFetchDto.DtoStatus = DtoStatus.Error;
                    resFetchDto.DtoStatusNotes.Exception = _pActivityInfo.Value.ToString();
                    resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());

                }
            }
            catch (Exception ex)
            {
                resFetchDto.DtoStatus = DtoStatus.Error;
                resFetchDto.DtoStatusNotes.Exception = ex.Message;
                resFetchDto.DtoStatusNotes.ExtraNotes.Add(ex.Message);
            }
            return resFetchDto;
        }
    
        public FetchDto SkipNGetN_OfSizeDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            FetchDto resFetchDto = new FetchDto();
            resFetchDto.DtoStatus = DtoStatus.Failed;
            try
            {
                var _pCustomerID = new SqlParameter
                {
                    ParameterName = "@pCustomerID",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = pCustomerID
                };
                var _pIsActive = new SqlParameter
                {
                    ParameterName = "@pIsActive",
                    SqlDbType = SqlDbType.Bit,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pIsActive == null ? (object)DBNull.Value : pIsActive.Value)
                };
                var _pSearchTxt = new SqlParameter
                {
                    ParameterName = "@pSearchTxt",
                    SqlDbType = SqlDbType.VarChar,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pSearchTxt == null ? (object)DBNull.Value : pSearchTxt)
                };
                var _pSkipNo = new SqlParameter
                {
                    ParameterName = "@pSkipNo",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = false,
                    Direction = ParameterDirection.Input,
                    Value = pSkipNo
                };
                var _pTakeNo = new SqlParameter
                {
                    ParameterName = "@pTakeNo",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pTakeNo == null ? (object)DBNull.Value : pTakeNo.Value)
                };
                var _pTotalCount = new SqlParameter
                {
                    ParameterName = "@pTotalCount",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };
                var _pActivityInfo = new SqlParameter
                {
                    ParameterName = "@pActivityInfo",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 500,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };
                var _pIsSucceeded = new SqlParameter
                {
                    ParameterName = "@pIsSucceeded",
                    SqlDbType = SqlDbType.Bit,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };



                resFetchDto.SizeInfoCollection = EntitiesContext.Database.SqlQuery<SizeInfoBo>("EXEC [dbo].[proc_FetchSizes]  @pCustomerID, @pIsActive, @pSearchTxt, @pSkipNo, @pTakeNo, @pTotalCount out, @pActivityInfo out , @pIsSucceeded out ", _pCustomerID, _pIsActive, _pSearchTxt, _pSkipNo, _pTakeNo, _pTotalCount, _pActivityInfo, _pIsSucceeded).ToList();

                if (Convert.ToBoolean(_pIsSucceeded.Value))
                {
                    if (resFetchDto.SizeInfoCollection != null && resFetchDto.SizeInfoCollection.Count() > 0)
                    {
                        resFetchDto.SelectedCount = resFetchDto.SizeInfoCollection.Count();
                        resFetchDto.TotalCount = (int)_pTotalCount.Value;
                        resFetchDto.DtoStatusNotes = new DtoStatusNotes();
                        resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                        resFetchDto.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        resFetchDto.DtoStatus = DtoStatus.NoDataFound;
                        resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                    }
                }
                else
                {
                    resFetchDto.DtoStatus = DtoStatus.Error;
                    resFetchDto.DtoStatusNotes.Exception = _pActivityInfo.Value.ToString();
                    resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());

                }
            }
            catch (Exception ex)
            {
                resFetchDto.DtoStatus = DtoStatus.Error;
                resFetchDto.DtoStatusNotes.Exception = ex.Message;
                resFetchDto.DtoStatusNotes.ExtraNotes.Add(ex.Message);
            }
            return resFetchDto;
        }
    
        public FetchDto SkipNGetN_OfColorDataWithSearch(int pCustomerID, bool? pIsActive, string pSearchTxt, int pSkipNo, int? pTakeNo)
        {
            FetchDto resFetchDto = new FetchDto();
            resFetchDto.DtoStatus = DtoStatus.Failed;
            try
            {
                var _pCustomerID = new SqlParameter
                {
                    ParameterName = "@pCustomerID",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = pCustomerID
                };
                var _pIsActive = new SqlParameter
                {
                    ParameterName = "@pIsActive",
                    SqlDbType = SqlDbType.Bit,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pIsActive == null ? (object)DBNull.Value : pIsActive.Value)
                };
                var _pSearchTxt = new SqlParameter
                {
                    ParameterName = "@pSearchTxt",
                    SqlDbType = SqlDbType.VarChar,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pSearchTxt == null ? (object)DBNull.Value : pSearchTxt)
                };
                var _pSkipNo = new SqlParameter
                {
                    ParameterName = "@pSkipNo",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = false,
                    Direction = ParameterDirection.Input,
                    Value = pSkipNo
                };
                var _pTakeNo = new SqlParameter
                {
                    ParameterName = "@pTakeNo",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (pTakeNo == null ? (object)DBNull.Value : pTakeNo.Value)
                };
                var _pTotalCount = new SqlParameter
                {
                    ParameterName = "@pTotalCount",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };
                var _pActivityInfo = new SqlParameter
                {
                    ParameterName = "@pActivityInfo",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 500,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };
                var _pIsSucceeded = new SqlParameter
                {
                    ParameterName = "@pIsSucceeded",
                    SqlDbType = SqlDbType.Bit,
                    IsNullable = true,
                    Direction = ParameterDirection.Output
                };



                resFetchDto.ColorInfoCollection = EntitiesContext.Database.SqlQuery<ColorInfoBo>("EXEC [dbo].[proc_FetchColors]  @pCustomerID, @pIsActive, @pSearchTxt, @pSkipNo, @pTakeNo, @pTotalCount out, @pActivityInfo out , @pIsSucceeded out ", _pCustomerID, _pIsActive, _pSearchTxt, _pSkipNo, _pTakeNo, _pTotalCount, _pActivityInfo, _pIsSucceeded).ToList();

                if (Convert.ToBoolean(_pIsSucceeded.Value))
                {
                    if (resFetchDto.ColorInfoCollection != null && resFetchDto.ColorInfoCollection.Count() > 0)
                    {
                        resFetchDto.SelectedCount = resFetchDto.ColorInfoCollection.Count();
                        resFetchDto.TotalCount = (int)_pTotalCount.Value;
                        resFetchDto.DtoStatusNotes = new DtoStatusNotes();
                        resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                        resFetchDto.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        resFetchDto.DtoStatus = DtoStatus.NoDataFound;
                        resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                    }
                }
                else
                {
                    resFetchDto.DtoStatus = DtoStatus.Error;
                    resFetchDto.DtoStatusNotes.Exception = _pActivityInfo.Value.ToString();
                    resFetchDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());

                }
            }
            catch (Exception ex)
            {
                resFetchDto.DtoStatus = DtoStatus.Error;
                resFetchDto.DtoStatusNotes.Exception = ex.Message;
                resFetchDto.DtoStatusNotes.ExtraNotes.Add(ex.Message);
            }
            return resFetchDto;
        }
    
    }
}
