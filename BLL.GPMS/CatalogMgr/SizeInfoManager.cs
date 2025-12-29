using Entities.GPMS;
using MODEL.GPMS;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.GPMS
{
    public class SizeInfoManager : DbBase
    {
        /// <summary>
        /// Add new Size Info.
        /// </summary>
        /// <param name="pSizeInfoBo"></param>
        /// <returns></returns>
        public CatalogDto AddSize(SizeInfoBo pSizeInfoBo)
        {
            var resCatalogDto = new CatalogDto();
            try
            {
                SizeInfo SizeInfo = new SizeInfo();

                // validate
                if (pSizeInfoBo.SizeCode == null)
                {
                    throw new UserException("Please provide a valid Size Code.");
                }
                if (pSizeInfoBo.SizeName == null)
                {
                    throw new UserException("Please provide a valid Size Name.");
                }
                if (pSizeInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                if (pSizeInfoBo.CreatedByID == null)
                {
                    throw new UserException("CreatedByID can't be null");
                }
                // validate

                SizeInfo.SizeCode = pSizeInfoBo.SizeCode;
                SizeInfo.SizeName = pSizeInfoBo.SizeName;
                SizeInfo.Description = pSizeInfoBo.Description;
                SizeInfo.IsActive = pSizeInfoBo.IsActive;
                SizeInfo.CreatedBy = pSizeInfoBo.CreatedBy;
                SizeInfo.CreatedByID = pSizeInfoBo.CreatedByID;
                SizeInfo.CreatedAt = DateTime.Now;
                SizeInfo.UpdatedCount = 0;

                EntitiesContext.SizeInfoes.Add(SizeInfo);
                if (EntitiesContext.SaveChanges() > 0)
                {
                    new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pSizeInfoBo.CreatedByID.Value);
                    resCatalogDto.DtoStatus = DtoStatus.Success;
                    resCatalogDto.SizeInfoBo = new SizeInfoBo();
                    resCatalogDto.SizeInfoBo.ID = SizeInfo.ID;
                }
                else
                {
                    resCatalogDto.DtoStatus = DtoStatus.RecordNotAdded;
                    resCatalogDto.DtoStatusNotes.ExtraNotes.Add("Error in save changes");
                }
            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        if (sqlEx.Number == 2627 || sqlEx.Number == 2601) // 2627 mean Violation in unique constraint & 2601 mean duplicate/unique index values
                        {
                            resCatalogDto.DtoStatus = DtoStatus.Error;
                            resCatalogDto.DtoStatusNotes.Exception = "Size code already exist.";
                            resCatalogDto.DtoStatusNotes.ExtraNotes.Add("Violation in unique constraint");
                        }
                    }
                    else
                    {
                        resCatalogDto.DtoStatus = DtoStatus.Error;
                        resCatalogDto.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    resCatalogDto.DtoStatus = DtoStatus.Error;
                    resCatalogDto.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                resCatalogDto.DtoStatus = DtoStatus.RecordNotAdded;
                resCatalogDto.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                resCatalogDto.DtoStatus = DtoStatus.Error;
                resCatalogDto.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return resCatalogDto;
        }

        /// <summary>
        /// Update existing Size.
        /// </summary>
        /// <param name="pSizeInfoBo"></param>
        /// <returns></returns>
        public CatalogDto UpdateSize(SizeInfoBo pSizeInfoBo)
        {
            CommonManager commonManager = new CommonManager();
            var res = new CatalogDto();
            try
            {
                // validate
                if (pSizeInfoBo.ID <= 0)
                {
                    throw new UserException("Please provide a valid Size ID.");
                }
                if (pSizeInfoBo.SizeCode == null)
                {
                    throw new UserException("Please provide a valid Size Code.");
                }
                if (pSizeInfoBo.SizeName == null)
                {
                    throw new UserException("Please provide a valid Size Name.");
                }
                if (pSizeInfoBo.IsActive == false)
                {
                    throw new UserException("Please provide a valid IsActive: 'true'.");
                }
                if (pSizeInfoBo.UpdatedByID == null)
                {
                    throw new UserException("UpdatedByID can't be null");
                }
                // validate

                var retSize = EntitiesContext.SizeInfoes.Where(x => x.ID == pSizeInfoBo.ID).FirstOrDefault();
                if (retSize != null)
                {
                    retSize.SizeCode = pSizeInfoBo.SizeCode;
                    retSize.SizeName = pSizeInfoBo.SizeName;
                    retSize.Description = pSizeInfoBo.Description;
                    retSize.IsActive = pSizeInfoBo.IsActive;
                    retSize.UpdatedBy = pSizeInfoBo.UpdatedBy;
                    retSize.UpdatedByID = pSizeInfoBo.UpdatedByID;
                    retSize.UpdatedAt = DateTime.Now;
                    retSize.UpdatedCount = commonManager.IncrementUpdatedCount(retSize.UpdatedCount);

                    var response = EntitiesContext.SaveChanges();
                    if (response > 0)
                    {
                        new LogManager().LogUserAction(action: System.Reflection.MethodBase.GetCurrentMethod().Name, pSizeInfoBo.UpdatedByID.Value);
                        res.DtoStatus = DtoStatus.Success;              
                    }
                    else if (response <= 0)
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdatedWithoutChanges;
                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.RecordNotUpdated;
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }

            }
            catch (DbUpdateException db)
            {
                if (db.InnerException != null && db.InnerException.InnerException != null)
                {
                    if (db.InnerException.InnerException is SqlException)
                    {
                        var sqlEx = (SqlException)db.InnerException.InnerException;
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = sqlEx.Message.ToString();

                    }
                    else
                    {
                        res.DtoStatus = DtoStatus.Error;
                        res.DtoStatusNotes.Exception = db.Message.ToString();
                    }
                }
                else
                {
                    res.DtoStatus = DtoStatus.Error;
                    res.DtoStatusNotes.Exception = db.Message.ToString();
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.RecordNotUpdated;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// Get Size Info against given Size Id.
        /// </summary>
        /// <param name="pSizeId"></param>
        /// <returns></returns>
        public CatalogDto GetSizeById(int pSizeId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pSizeId <= 0)
                {
                    throw new UserException("Please provide a valid Size ID.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var Size = EntitiesContext.SizeInfoes.Where(x => x.ID == pSizeId).FirstOrDefault();
                if (Size != null)
                {
                    res.SizeInfoBo = new SizeInfoBo();
                    res.SizeInfoBo.ID = Size.ID;
                    res.SizeInfoBo.SizeCode = Size.SizeCode;
                    res.SizeInfoBo.SizeName = Size.SizeName;
                    res.SizeInfoBo.Description = Size.Description;
                    res.SizeInfoBo.IsActive = Size.IsActive;
                    res.SizeInfoBo.CreatedBy = Size.CreatedBy;
                    res.SizeInfoBo.CreatedAt = Size.CreatedAt;
                    res.SizeInfoBo.UpdatedBy = Size.UpdatedBy;
                    res.SizeInfoBo.UpdatedAt = Size.UpdatedAt;
                    res.SizeInfoBo.UpdatedCount = Size.UpdatedCount;
                    res.SizeInfoBo.Notes = Size.Notes;
                   
                    //For POSizeD 
                    res.SizeInfoBo.POSizeDCollection = new List<POSizeDBo>();
                    foreach (var pOSizeD in Size.POSizeDs)
                    {
                        POSizeDBo POSizeDBo = new POSizeDBo();
                        POSizeDBo.ID = pOSizeD.ID;
                        POSizeDBo.PODID = pOSizeD.PODID;

                        res.SizeInfoBo.POSizeDCollection.Add(POSizeDBo);
                    }

                    res.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// Get Size Info against given Size Code.
        /// </summary>
        /// <param name="pSizeCode"></param>
        /// <returns></returns>
        public CatalogDto GetSizeByCode(string pSizeCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pSizeCode == null)
                {
                    throw new UserException("Please provide a valid Size Code.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var Size = EntitiesContext.SizeInfoes.Where(x => x.SizeCode == pSizeCode).FirstOrDefault();
                if (Size != null)
                {
                    res.SizeInfoBo = new SizeInfoBo();
                    res.SizeInfoBo.ID = Size.ID;
                    res.SizeInfoBo.SizeCode = Size.SizeCode;
                    res.SizeInfoBo.SizeName = Size.SizeName;
                    res.SizeInfoBo.Description = Size.Description;
                    res.SizeInfoBo.IsActive = Size.IsActive;
                    res.SizeInfoBo.CreatedBy = Size.CreatedBy;
                    res.SizeInfoBo.CreatedAt = Size.CreatedAt;
                    res.SizeInfoBo.UpdatedBy = Size.UpdatedBy;
                    res.SizeInfoBo.UpdatedAt = Size.UpdatedAt;
                    res.SizeInfoBo.UpdatedCount = Size.UpdatedCount;
                    res.SizeInfoBo.Notes = Size.Notes;
                    
                    //For POSizeD 
                    res.SizeInfoBo.POSizeDCollection = new List<POSizeDBo>();
                    foreach (var pOSizeD in Size.POSizeDs)
                    {
                        POSizeDBo POSizeDBo = new POSizeDBo();
                        POSizeDBo.ID = pOSizeD.ID;
                        POSizeDBo.PODID = pOSizeD.PODID;

                        res.SizeInfoBo.POSizeDCollection.Add(POSizeDBo);
                    }

                    res.DtoStatus = DtoStatus.Success;

                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

        /// <summary>
        /// To Get all Sizes then pass parameter value as 'null'. 
        /// To Get all active Sizes then pass parameter value as 'true'. 
        /// To Get all In-active Sizes then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllSizes(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<SizeInfo> SizeList;
                if (pIsActive.HasValue)
                    SizeList = EntitiesContext.SizeInfoes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    SizeList = EntitiesContext.SizeInfoes.ToList();

                if (SizeList != null && SizeList.Count > 0)
                {
                    res.SizeInfoCollection = new List<SizeInfoBo>();
                    foreach (var Size in SizeList)
                    {
                        SizeInfoBo SizeInfoBo = new SizeInfoBo();
                        SizeInfoBo.ID = Size.ID;
                        SizeInfoBo.SizeCode = Size.SizeCode;
                        SizeInfoBo.SizeName = Size.SizeName;
                        SizeInfoBo.Description = Size.Description;
                        SizeInfoBo.IsActive = Size.IsActive;
                        SizeInfoBo.CreatedBy = Size.CreatedBy;
                        SizeInfoBo.CreatedAt = Size.CreatedAt;
                        SizeInfoBo.UpdatedBy = Size.UpdatedBy;
                        SizeInfoBo.UpdatedAt = Size.UpdatedAt;
                        SizeInfoBo.UpdatedCount = Size.UpdatedCount;
                        SizeInfoBo.Notes = Size.Notes;

                        //For POSizeD 
                        SizeInfoBo.POSizeDCollection = new List<POSizeDBo>();
                        foreach (var pOSizeD in Size.POSizeDs)
                        {
                            POSizeDBo POSizeDBo = new POSizeDBo();
                            POSizeDBo.ID = pOSizeD.ID;
                            POSizeDBo.PODID = pOSizeD.PODID;

                            SizeInfoBo.POSizeDCollection.Add(POSizeDBo);
                        }

                        res.SizeInfoCollection.Add(SizeInfoBo);

                    }
                    res.DtoStatus = DtoStatus.Success;
                }
                else
                {
                    res.DtoStatus = DtoStatus.NoDataFound;
                }
            }
            catch (UserException ux)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = ux.Message.ToString();
            }
            catch (Exception e)
            {
                res.DtoStatus = DtoStatus.Error;
                res.DtoStatusNotes.Exception = e.Message.ToString();
            }
            return res;
        }

    }
}
