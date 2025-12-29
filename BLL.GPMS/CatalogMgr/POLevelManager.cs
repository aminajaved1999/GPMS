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
    public class POLevelManager : DbBase
    {

        /// <summary>
        /// Get POLevel Info against given POLevel Id.
        /// </summary>
        /// <param name="pPOLevelId"></param>
        /// <returns></returns>
        public CatalogDto GetPOLevelById(int pPOLevelId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPOLevelId <= 0)
                {
                    throw new UserException("Please provide a valid PO Level ID.");
                }
                res.DtoStatus = DtoStatus.Failed;
                var POLevel = EntitiesContext.POLevels.Where(x => x.ID == pPOLevelId).FirstOrDefault();
                if (POLevel != null)
                {
                    res.POLevelBo = new POLevelBo();
                    res.POLevelBo.ID = POLevel.ID;
                    res.POLevelBo.POLevelCode = POLevel.POLevelCode;
                    res.POLevelBo.POLevelName = POLevel.POLevelName;
                    res.POLevelBo.Description = POLevel.Description;
                    res.POLevelBo.IsActive = POLevel.IsActive;
                    res.POLevelBo.CreatedBy = POLevel.CreatedBy;
                    res.POLevelBo.CreatedAt = POLevel.CreatedAt;
                    res.POLevelBo.UpdatedBy = POLevel.UpdatedBy;
                    res.POLevelBo.UpdatedAt = POLevel.UpdatedAt;
                    res.POLevelBo.UpdatedCount = POLevel.UpdatedCount;
                    res.POLevelBo.Notes = POLevel.Notes;
                    res.POLevelBo.POMCollection = new List<POMBo>();
                    foreach (var pom in POLevel.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.POLevelBo.POMCollection.Add(pOMBo);
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
        /// Get POLevel Info against given POLevel Code.
        /// </summary>
        /// <param name="pPOLevelCode"></param>
        /// <returns></returns>
        public CatalogDto GetPOLevelByCode(string pPOLevelCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPOLevelCode == null)
                {
                    throw new UserException("Please provide a valid POLevel Code.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var POLevel = EntitiesContext.POLevels.Where(x => x.POLevelCode == pPOLevelCode).FirstOrDefault();
                if (POLevel != null)
                {
                    res.POLevelBo = new POLevelBo();
                    res.POLevelBo.ID = POLevel.ID;
                    res.POLevelBo.POLevelCode = POLevel.POLevelCode;
                    res.POLevelBo.POLevelName = POLevel.POLevelName;
                    res.POLevelBo.Description = POLevel.Description;
                    res.POLevelBo.IsActive = POLevel.IsActive;
                    res.POLevelBo.CreatedBy = POLevel.CreatedBy;
                    res.POLevelBo.CreatedAt = POLevel.CreatedAt;
                    res.POLevelBo.UpdatedBy = POLevel.UpdatedBy;
                    res.POLevelBo.UpdatedAt = POLevel.UpdatedAt;
                    res.POLevelBo.UpdatedCount = POLevel.UpdatedCount;
                    res.POLevelBo.Notes = POLevel.Notes;
                    //for POMCollection
                    res.POLevelBo.POMCollection = new List<POMBo>();
                    foreach (var pom in POLevel.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.POLevelBo.POMCollection.Add(pOMBo);
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
        /// To Get all POLevels then pass parameter value as 'null'. 
        /// To Get all active POLevels then pass parameter value as 'true'. 
        /// To Get all In-active POLevels then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllPOLevels(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<POLevel> POLevelList;
                if (pIsActive.HasValue)
                    POLevelList = EntitiesContext.POLevels.Where(x => x.IsActive == pIsActive).ToList();
                else
                    POLevelList = EntitiesContext.POLevels.ToList();

                if (POLevelList != null && POLevelList.Count > 0)
                {
                    res.POLevelCollection = new List<POLevelBo>();
                    foreach (var POLevel in POLevelList)
                    {
                        POLevelBo POLevelBo = new POLevelBo();
                        POLevelBo.ID = POLevel.ID;
                        POLevelBo.POLevelCode = POLevel.POLevelCode;
                        POLevelBo.POLevelName = POLevel.POLevelName;
                        POLevelBo.Description = POLevel.Description;
                        POLevelBo.IsActive = POLevel.IsActive;
                        POLevelBo.CreatedBy = POLevel.CreatedBy;
                        POLevelBo.CreatedAt = POLevel.CreatedAt;
                        POLevelBo.UpdatedBy = POLevel.UpdatedBy;
                        POLevelBo.UpdatedAt = POLevel.UpdatedAt;
                        POLevelBo.UpdatedCount = POLevel.UpdatedCount;
                        POLevelBo.Notes = POLevel.Notes;
                        //for POMCollection
                        POLevelBo.POMCollection = new List<POMBo>();
                        foreach (var pom in POLevel.POMs)
                        {
                            POMBo pOMBo = new POMBo();
                            pOMBo.ID = pom.ID;
                            POLevelBo.POMCollection.Add(pOMBo);
                        }
                        res.POLevelCollection.Add(POLevelBo);

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
