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
    public class POFormManager : DbBase
    {

        /// <summary>
        /// Get POForm Info against given POForm Id.
        /// </summary>
        /// <param name="pPOFormId"></param>
        /// <returns></returns>
        public CatalogDto GetPOFormById(int pPOFormId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPOFormId <= 0)
                {
                    throw new UserException("Please provide a valid PO Form ID.");
                }
                res.DtoStatus = DtoStatus.Failed;
                var poFrom = EntitiesContext.POFroms.Where(x => x.ID == pPOFormId).FirstOrDefault();
                if (poFrom != null)
                {
                    res.POFormBo = new POFromBo();
                    res.POFormBo.ID = poFrom.ID;
                    res.POFormBo.POFromCode = poFrom.POFromCode;
                    res.POFormBo.POFromName = poFrom.POFromName;
                    res.POFormBo.Description = poFrom.Description;
                    res.POFormBo.IsActive = poFrom.IsActive;
                    res.POFormBo.CreatedBy = poFrom.CreatedBy;
                    res.POFormBo.CreatedAt = poFrom.CreatedAt;
                    res.POFormBo.UpdatedBy = poFrom.UpdatedBy;
                    res.POFormBo.UpdatedAt = poFrom.UpdatedAt;
                    res.POFormBo.UpdatedCount = poFrom.UpdatedCount;
                    res.POFormBo.Notes = poFrom.Notes;
                    //for POMCollection
                    res.POFormBo.POMCollection = new List<POMBo>();
                    foreach (var pom in poFrom.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.POFormBo.POMCollection.Add(pOMBo);
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
        /// Get POForm Info against given POForm Code.
        /// </summary>
        /// <param name="pPOFormCode"></param>
        /// <returns></returns>
        public CatalogDto GetPOFormByCode(string pPOFormCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPOFormCode == null)
                {
                    throw new UserException("Please provide a valid POForm Code.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var poFrom = EntitiesContext.POFroms.Where(x => x.POFromCode == pPOFormCode).FirstOrDefault();
                if (poFrom != null)
                {
                    res.POFormBo = new POFromBo();
                    res.POFormBo.ID = poFrom.ID;
                    res.POFormBo.POFromCode = poFrom.POFromCode;
                    res.POFormBo.POFromName = poFrom.POFromName;
                    res.POFormBo.Description = poFrom.Description;
                    res.POFormBo.IsActive = poFrom.IsActive;
                    res.POFormBo.CreatedBy = poFrom.CreatedBy;
                    res.POFormBo.CreatedAt = poFrom.CreatedAt;
                    res.POFormBo.UpdatedBy = poFrom.UpdatedBy;
                    res.POFormBo.UpdatedAt = poFrom.UpdatedAt;
                    res.POFormBo.UpdatedCount = poFrom.UpdatedCount;
                    res.POFormBo.Notes = poFrom.Notes;
                    //for POMCollection
                    res.POFormBo.POMCollection = new List<POMBo>();
                    foreach (var pom in poFrom.POMs)
                    {
                        POMBo pOMBo = new POMBo();
                        pOMBo.ID = pom.ID;
                        res.POFormBo.POMCollection.Add(pOMBo);
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
        /// To Get all POForms then pass parameter value as 'null'. 
        /// To Get all active POForms then pass parameter value as 'true'. 
        /// To Get all In-active POForms then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllPOForms(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<POFrom> POFormList;
                if (pIsActive.HasValue)
                    POFormList = EntitiesContext.POFroms.Where(x => x.IsActive == pIsActive).ToList();
                else
                    POFormList = EntitiesContext.POFroms.ToList();

                if (POFormList != null && POFormList.Count > 0)
                {
                    res.POFormCollection = new List<POFromBo>();
                    foreach (var POFrom in POFormList)
                    {
                        POFromBo POFormBo = new POFromBo();
                        POFormBo.ID = POFrom.ID;
                        POFormBo.POFromCode = POFrom.POFromCode;
                        POFormBo.POFromName = POFrom.POFromName;
                        POFormBo.Description = POFrom.Description;
                        POFormBo.IsActive = POFrom.IsActive;
                        POFormBo.CreatedBy = POFrom.CreatedBy;
                        POFormBo.CreatedAt = POFrom.CreatedAt;
                        POFormBo.UpdatedBy = POFrom.UpdatedBy;
                        POFormBo.UpdatedAt = POFrom.UpdatedAt;
                        POFormBo.UpdatedCount = POFrom.UpdatedCount;
                        POFormBo.Notes = POFrom.Notes;
                        //for POMCollection
                        POFormBo.POMCollection = new List<POMBo>();
                        foreach (var pom in POFrom.POMs)
                        {
                            POMBo pOMBo = new POMBo();
                            pOMBo.ID = pom.ID;
                            POFormBo.POMCollection.Add(pOMBo);
                        }
                        res.POFormCollection.Add(POFormBo);

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
