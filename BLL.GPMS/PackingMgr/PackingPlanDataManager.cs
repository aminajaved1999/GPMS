using Entities.GPMS;
using MODEL.GPMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GPMS
{
    public class PackingPlanDataManager : DbBase
    {
        /// <summary>
        /// Add new Packing Plan Data.
        /// </summary>
        /// <param name="packingPlanDataBo"></param>
        /// <returns></returns>
        public PackingDto AddPackingPlanData(PackingDto packingDto)
        {
            var dbContext = new GPMSEntities();
            PackingDto resPackingPlanData = new PackingDto();
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (packingDto == null || packingDto.PackingPlanDataList == null || packingDto.PackingPlanDataList.Count == 0)
                    {
                        resPackingPlanData.DtoStatus = DtoStatus.RecordNotAdded;
                        resPackingPlanData.DtoStatusNotes.Exception = "Input data is null or empty.";
                        return resPackingPlanData;
                    }

                    List<int> addedIds = new List<int>();
                    int savedChanges = 0;
                    foreach (var packingPlanDataBo in packingDto.PackingPlanDataList)
                    {
                        if (packingPlanDataBo == null)
                            continue;

                        // Validation
                        if (string.IsNullOrEmpty(packingPlanDataBo.SourceFileName))
                            throw new UserException("Source file name cannot be null/empty.");
                        if (packingPlanDataBo.CreatedByID == null)
                            throw new UserException("CreatedByID can't be null.");

                        // Create new PackingPlanData entity
                        PackingPlanData packingPlanData = new PackingPlanData
                        {
                            CustomerID = packingPlanDataBo.CustomerID,
                            SourceFileName = packingPlanDataBo.SourceFileName,
                            PONo = packingPlanDataBo.PONo,
                            GroupNo = packingPlanDataBo.GroupNo,
                            GroupCaseQty = packingPlanDataBo.GroupCaseQty,
                            ItemQtyPerCase = packingPlanDataBo.ItemQtyPerCase,
                            ItemNo = packingPlanDataBo.ItemNo,
                            StoreNo = packingPlanDataBo.StoreNo,
                            DC = packingPlanDataBo.DC,
                            UccPartners = packingPlanDataBo.UccPartners,
                            UccType = packingPlanDataBo.UccType,
                            UccCoo = packingPlanDataBo.UccCoo,
                            Description = packingPlanDataBo.Description,
                            CreatedBy = packingPlanDataBo.CreatedBy,
                            CreatedByID = packingPlanDataBo.CreatedByID,
                            CreatedAt = DateTime.Now,
                            Notes = packingPlanDataBo.Notes
                        };

                        // Add 
                        dbContext.PackingPlanDatas.Add(packingPlanData);
                        savedChanges = dbContext.SaveChanges();
                        addedIds.Add(packingPlanData.ID);
                    }

                    // Save changes
                    if (savedChanges > 0 && addedIds.Count > 0)
                    {
                        PackingDto packingLabelResult = GeneratePackingLabel(packingDto.PackingPlanDataList.FirstOrDefault().CustomerID, addedIds.FirstOrDefault(), addedIds.Last(), dbContext);

                        if (packingLabelResult.DtoStatus == DtoStatus.Success)
                        {
                            // Log 
                            new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, packingDto.PackingPlanDataList.FirstOrDefault()?.CreatedByID ?? 0);
                            resPackingPlanData.DtoStatus = DtoStatus.Success;
                        }
                        else
                        {
                            transaction.Rollback();
                            resPackingPlanData.DtoStatus = packingLabelResult.DtoStatus;
                            resPackingPlanData.DtoStatusNotes = packingLabelResult.DtoStatusNotes;
                            return resPackingPlanData;
                        }
                    }
                    else
                    {
                        resPackingPlanData.DtoStatus = DtoStatus.RecordNotAdded;
                        resPackingPlanData.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                    }

                    // Commit transaction
                    transaction.Commit();
                }
                catch (UserException ux)
                {
                    transaction.Rollback();
                    resPackingPlanData.DtoStatus = DtoStatus.RecordNotAdded;
                    resPackingPlanData.DtoStatusNotes.Exception = ux.Message;
                    return resPackingPlanData;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    resPackingPlanData.DtoStatus = DtoStatus.Error;
                    resPackingPlanData.DtoStatusNotes.Exception = e.Message;
                    return resPackingPlanData;
                }
                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }

            return resPackingPlanData;
        }

        public ValidationDto IsPackingPlanAlreadyProcessed(string pFileName)
        {
            var validationDto = new ValidationDto();
            try
            {
                //validate
                if (pFileName == null)
                {
                    throw new UserException("Please provide valid File Name");
                }
                //

                bool pFileNameExists = EntitiesContext.PackingPlanDatas.Any(x => x.SourceFileName == pFileName);

                if (pFileNameExists)
                {
                    validationDto.IsExist = true;
                    validationDto.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    validationDto.IsExist = false;
                    validationDto.DtoStatus = DtoStatus.NoDataFound;


                }
            }
            catch (UserException ux)
            {
                validationDto.DtoStatus = DtoStatus.RecordNotAdded;
                validationDto.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                validationDto.DtoStatus = DtoStatus.Error;
                validationDto.DtoStatusNotes.Exception = e.Message.ToString();
            }

            return validationDto;
        }

        public virtual PackingDto GeneratePackingLabel(int? pCustomerID, int? startID, int? endID, GPMSEntities pEntityContext)
        {

            if (pCustomerID <= 0)
            {
                throw new UserException("CustomerID cannot be null/empty.");
            }
            if (startID <= 0)
            {
                throw new UserException("startID cannot be null/empty.");
            }
            if (endID <= 0)
            {
                throw new UserException("endID cannot be null/empty.");
            }


            PackingDto packingDto = new PackingDto();
            packingDto.DtoStatus = DtoStatus.Failed;
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
                var _startID = new SqlParameter
                {
                    ParameterName = "@startID",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (startID == null ? (object)DBNull.Value : startID.Value)
                };
                var _endID = new SqlParameter
                {
                    ParameterName = "@endID",
                    SqlDbType = SqlDbType.Int,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    Value = (endID == null ? (object)DBNull.Value : endID)
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


                packingDto.PackingPlanDataList =
                    pEntityContext.Database.SqlQuery<PackingPlanDataBo>
                    ("EXEC [dbo].[proc_GeneratePackingLabel]  @pCustomerID, @startID, @endID, @pActivityInfo out , @pIsSucceeded out ",
                    _pCustomerID, _startID, _endID, _pActivityInfo, _pIsSucceeded).ToList();

                if (Convert.ToBoolean(_pIsSucceeded.Value))
                {

                    packingDto.DtoStatusNotes = new DtoStatusNotes();
                    packingDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                    packingDto.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    packingDto.DtoStatus = DtoStatus.Error;
                    packingDto.DtoStatusNotes.Exception = _pActivityInfo.Value.ToString();
                    packingDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());

                }
            }
            catch (UserException ux)
            {
                packingDto.DtoStatus = DtoStatus.Error;
                packingDto.DtoStatusNotes.Exception = ux.Message;
            }
            catch (Exception ex)
            {
                packingDto.DtoStatus = DtoStatus.Error;
                packingDto.DtoStatusNotes.Exception = ex.Message;
            }
            return packingDto;
        }

        public virtual PackingDto GetLabels_AcdSprt(int? pCustomerID, string pPONo, DateTime? pCreatedDate)
        {
            PackingDto packingDto = new PackingDto();
            packingDto.DtoStatus = DtoStatus.Failed;
            packingDto.DataTable = new DataTable();

            if (pCustomerID <= 0)
            {
                throw new UserException("CustomerID cannot be null/empty.");
            }

            if (pPONo == null)
            {
                throw new UserException("PO cannot be null/empty.");
            }

            if (pCreatedDate == default)
            {
                throw new UserException("Please Provide valid Created Date.");
            }

            try
            {
                using (GPMSEntities EntityContext = new GPMSEntities())
                {
                    var _pCustomerID = new SqlParameter
                    {
                        ParameterName = "@pCustomerID",
                        SqlDbType = SqlDbType.Int,
                        IsNullable = true,
                        Direction = ParameterDirection.Input,
                        Value = pCustomerID
                    };

                    var _pPONo = new SqlParameter
                    {
                        ParameterName = "@pPONo",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        IsNullable = true,
                        Direction = ParameterDirection.Input,
                        Value = pPONo ?? (object)DBNull.Value
                    };
                    var _pCreatedDate = new SqlParameter
                    {
                        ParameterName = "@pCreatedDate",
                        SqlDbType = SqlDbType.DateTime,
                        IsNullable = true,
                        Direction = ParameterDirection.Input,
                        Value = pCreatedDate ?? (object)DBNull.Value
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

                    var result = EntityContext.Database.SqlQuery<GetLabels_AcdSprt_Result>(
                        "EXEC [dbo].[GetLabels_AcdSprt] @pCustomerID, @pPONo, @pCreatedDate, @pActivityInfo out, @pIsSucceeded out",
                        _pCustomerID, _pPONo, _pCreatedDate, _pActivityInfo, _pIsSucceeded).ToList();


                    if (Convert.ToBoolean(_pIsSucceeded.Value))
                    {
                        packingDto.DataTable.TableName = "Data";
                        packingDto.DataTable.Columns.Add("ShipToName");
                        packingDto.DataTable.Columns.Add("ShipAddress");
                        packingDto.DataTable.Columns.Add("ShipCityState");
                        packingDto.DataTable.Columns.Add("PO");
                        packingDto.DataTable.Columns.Add("boxbarcode");
                        packingDto.DataTable.Columns.Add("TOTAL", typeof(int));
                        packingDto.DataTable.Columns.Add("CURRENT", typeof(long));
                        packingDto.DataTable.Columns.Add("POSTALCODE");
                        packingDto.DataTable.Columns.Add("dept");
                        packingDto.DataTable.Columns.Add("scac");
                        packingDto.DataTable.Columns.Add("caseno");

                        foreach (var item in result)
                        {
                            packingDto.DataTable.Rows.Add(
                                item.ShipToName,
                                item.ShipAddress,
                                item.ShipCityState,
                                item.PO,
                                item.boxbarcode,
                                item.TOTAL,
                                item.CURRENT,
                                item.POSTALCODE,
                                item.dept,
                                item.scac,
                                item.caseno
                            );
                        }
                        packingDto.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        packingDto.DtoStatus = DtoStatus.Error;
                        packingDto.DtoStatusNotes.Exception = _pActivityInfo.Value.ToString();
                        packingDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());
                    }
                }
            }
            catch (UserException ux)
            {
                packingDto.DtoStatus = DtoStatus.Error;
                packingDto.DtoStatusNotes.Exception = ux.Message;
            }
            catch (Exception ex)
            {
                packingDto.DtoStatus = DtoStatus.Error;
                packingDto.DtoStatusNotes.Exception = ex.Message;
            }

            return packingDto;
        }

        public virtual PackingDto GetPackQty(int? pCustomerID, string pPONo, DateTime? pCreatedDate)
        {
            PackingDto packingDto = new PackingDto();
            packingDto.DtoStatus = DtoStatus.Failed;
            packingDto.DataTable = new DataTable();

            try
            {
                if (pCustomerID <= 0)
                {
                    throw new UserException("CustomerID cannot be null/empty.");
                }

                if (pPONo == null)
                {
                    throw new UserException("PO cannot be null/empty.");
                }

                if (pCreatedDate == default)
                {
                    throw new UserException("Please Provide valid Created Date.");
                }

                using (GPMSEntities pEntityContext = new GPMSEntities())
                {

                    var _pCustomerID = new SqlParameter
                    {
                        ParameterName = "@pCustomerID",
                        SqlDbType = SqlDbType.Int,
                        IsNullable = true,
                        Direction = ParameterDirection.Input,
                        Value = pCustomerID
                    };

                    var _pPONo = new SqlParameter
                    {
                        ParameterName = "@pPONo",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        IsNullable = true,
                        Direction = ParameterDirection.Input,
                        Value = pPONo ?? (object)DBNull.Value
                    };
                    var _pCreatedDate = new SqlParameter
                    {
                        ParameterName = "@pCreatedDate",
                        SqlDbType = SqlDbType.DateTime,
                        IsNullable = true,
                        Direction = ParameterDirection.Input,
                        Value = pCreatedDate ?? (object)DBNull.Value
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

                    var result = pEntityContext.Database.SqlQuery<GetPackQty_Result>("EXEC [dbo].[GetPackQty] @pCustomerID, @pPONo, @pCreatedDate, @pActivityInfo out, @pIsSucceeded out",
                        _pCustomerID, _pPONo, _pCreatedDate, _pActivityInfo, _pIsSucceeded).ToList();

                    if (result != null && result.Count > 0)
                    {
                        packingDto.DataTable.TableName = "Data";
                        packingDto.DataTable.Columns.Add("PONo");
                        packingDto.DataTable.Columns.Add("BoxBarcode");
                        packingDto.DataTable.Columns.Add("upc");
                        packingDto.DataTable.Columns.Add("StyleName");
                        packingDto.DataTable.Columns.Add("ColorName");
                        packingDto.DataTable.Columns.Add("SizeName");
                        packingDto.DataTable.Columns.Add("ItemQtyPerCase", typeof(int));
                        packingDto.DataTable.Columns.Add("UserGivenStoreno");
                        packingDto.DataTable.Columns.Add("SystemStoreno", typeof(int));

                        foreach (var item in result)
                        {
                            packingDto.DataTable.Rows.Add(
                                item.PONo,
                                item.BoxBarcode,
                                item.upc,
                                item.StyleName,
                                item.ColorName,
                                item.SizeName,
                                item.ItemQtyPerCase,
                                item.UserGivenStoreno,
                                item.SystemStoreno
                            );
                        }
                        packingDto.DtoStatus = DtoStatus.Success;
                    }
                    else
                    {
                        packingDto.DtoStatus = DtoStatus.Error;
                        packingDto.DtoStatusNotes.Exception = _pActivityInfo.Value.ToString();
                        packingDto.DtoStatusNotes.ExtraNotes.Add(_pActivityInfo.Value.ToString());

                    }
                }
            }
            catch (UserException ux)
            {
                packingDto.DtoStatus = DtoStatus.Error;
                packingDto.DtoStatusNotes.Exception = ux.Message;
            }
            catch (Exception ex)
            {
                packingDto.DtoStatus = DtoStatus.Error;
                packingDto.DtoStatusNotes.Exception = ex.Message;
            }

            return packingDto;
        }



    }
}
