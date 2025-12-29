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
                var POForm = EntitiesContext.POForms.Where(x => x.ID == pPOFormId).FirstOrDefault();
                if (POForm != null)
                {
                    res.POFormBo = new POFormBo();
                    res.POFormBo.ID = POForm.ID;
                    res.POFormBo.POFormCode = POForm.POFormCode;
                    res.POFormBo.POFormName = POForm.POFormName;
                    res.POFormBo.Description = POForm.Description;
                    res.POFormBo.IsActive = POForm.IsActive;
                    res.POFormBo.CreatedBy = POForm.CreatedBy;
                    res.POFormBo.CreatedAt = POForm.CreatedAt;
                    res.POFormBo.UpdatedBy = POForm.UpdatedBy;
                    res.POFormBo.UpdatedAt = POForm.UpdatedAt;
                    res.POFormBo.UpdatedCount = POForm.UpdatedCount;
                    res.POFormBo.Notes = POForm.Notes;
                    //for POMCollection
                    res.POFormBo.POMCollection = new List<POMBo>();
                    foreach (var pom in POForm.POMs)
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
                var POForm = EntitiesContext.POForms.Where(x => x.POFormCode == pPOFormCode).FirstOrDefault();
                if (POForm != null)
                {
                    res.POFormBo = new POFormBo();
                    res.POFormBo.ID = POForm.ID;
                    res.POFormBo.POFormCode = POForm.POFormCode;
                    res.POFormBo.POFormName = POForm.POFormName;
                    res.POFormBo.Description = POForm.Description;
                    res.POFormBo.IsActive = POForm.IsActive;
                    res.POFormBo.CreatedBy = POForm.CreatedBy;
                    res.POFormBo.CreatedAt = POForm.CreatedAt;
                    res.POFormBo.UpdatedBy = POForm.UpdatedBy;
                    res.POFormBo.UpdatedAt = POForm.UpdatedAt;
                    res.POFormBo.UpdatedCount = POForm.UpdatedCount;
                    res.POFormBo.Notes = POForm.Notes;
                    //for POMCollection
                    res.POFormBo.POMCollection = new List<POMBo>();
                    foreach (var pom in POForm.POMs)
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
                List<POForm> POFormList;
                if (pIsActive.HasValue)
                    POFormList = EntitiesContext.POForms.Where(x => x.IsActive == pIsActive).ToList();
                else
                    POFormList = EntitiesContext.POForms.ToList();

                if (POFormList != null && POFormList.Count > 0)
                {
                    res.POFormCollection = new List<POFormBo>();
                    foreach (var POForm in POFormList)
                    {
                        POFormBo POFormBo = new POFormBo();
                        POFormBo.ID = POForm.ID;
                        POFormBo.POFormCode = POForm.POFormCode;
                        POFormBo.POFormName = POForm.POFormName;
                        POFormBo.Description = POForm.Description;
                        POFormBo.IsActive = POForm.IsActive;
                        POFormBo.CreatedBy = POForm.CreatedBy;
                        POFormBo.CreatedAt = POForm.CreatedAt;
                        POFormBo.UpdatedBy = POForm.UpdatedBy;
                        POFormBo.UpdatedAt = POForm.UpdatedAt;
                        POFormBo.UpdatedCount = POForm.UpdatedCount;
                        POFormBo.Notes = POForm.Notes;
                        //for POMCollection
                        POFormBo.POMCollection = new List<POMBo>();
                        foreach (var pom in POForm.POMs)
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
