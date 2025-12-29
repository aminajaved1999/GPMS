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
    public class POTypeManager : DbBase
    {

        /// <summary>
        /// Get POType Info against given POType Id.
        /// </summary>
        /// <param name="pPOTypeId"></param>
        /// <returns></returns>
        public CatalogDto GetPOTypeById(int pPOTypeId)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPOTypeId <= 0)
                {
                    throw new UserException("Please provide a valid PO Type ID.");
                }
                res.DtoStatus = DtoStatus.Failed;
                var POType = EntitiesContext.POTypes.Where(x => x.ID == pPOTypeId).FirstOrDefault();
                if (POType != null)
                {
                    res.POTypeBo = new POTypeBo();
                    res.POTypeBo.ID = POType.ID;
                    res.POTypeBo.POTypeCode = POType.POTypeCode;
                    res.POTypeBo.POTypeName = POType.POTypeName;
                    res.POTypeBo.LeadDays = POType.LeadDays;
                    res.POTypeBo.Description = POType.Description;
                    res.POTypeBo.IsActive = POType.IsActive;
                    res.POTypeBo.CreatedBy = POType.CreatedBy;
                    res.POTypeBo.CreatedAt = POType.CreatedAt;
                    res.POTypeBo.UpdatedBy = POType.UpdatedBy;
                    res.POTypeBo.UpdatedAt = POType.UpdatedAt;
                    res.POTypeBo.UpdatedCount = POType.UpdatedCount;
                    res.POTypeBo.Notes = POType.Notes;
                    //res.POTypeBo.POMCollection = POType.POMs;
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
        /// Get POType Info against given POType Code.
        /// </summary>
        /// <param name="pPOTypeCode"></param>
        /// <returns></returns>
        public CatalogDto GetPOTypeByCode(string pPOTypeCode)
        {
            var res = new CatalogDto();
            try
            {
                // validate
                if (pPOTypeCode == null)
                {
                    throw new UserException("Please provide a valid POType Code.");
                }
                // validate

                res.DtoStatus = DtoStatus.Failed;
                var POType = EntitiesContext.POTypes.Where(x => x.POTypeCode == pPOTypeCode).FirstOrDefault();
                if (POType != null)
                {
                    res.POTypeBo = new POTypeBo();
                    res.POTypeBo.ID = POType.ID;
                    res.POTypeBo.POTypeCode = POType.POTypeCode;
                    res.POTypeBo.POTypeName = POType.POTypeName;
                    res.POTypeBo.LeadDays = POType.LeadDays;
                    res.POTypeBo.Description = POType.Description;
                    res.POTypeBo.IsActive = POType.IsActive;
                    res.POTypeBo.CreatedBy = POType.CreatedBy;
                    res.POTypeBo.CreatedAt = POType.CreatedAt;
                    res.POTypeBo.UpdatedBy = POType.UpdatedBy;
                    res.POTypeBo.UpdatedAt = POType.UpdatedAt;
                    res.POTypeBo.UpdatedCount = POType.UpdatedCount;
                    res.POTypeBo.Notes = POType.Notes;
                    //res.POTypeBo.POMCollection = POType.POMs;

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
        /// To Get all POTypes then pass parameter value as 'null'. 
        /// To Get all active POTypes then pass parameter value as 'true'. 
        /// To Get all In-active POTypes then pass parameter value as 'false'. 
        /// </summary>
        /// <param name="pIsActive"></param>
        /// <returns></returns>
        public CatalogDto GetAllPOTypes(bool? pIsActive)
        {
            var res = new CatalogDto();
            try
            {
                res.DtoStatus = DtoStatus.Failed;
                List<POType> POTypeList;
                if (pIsActive.HasValue)
                    POTypeList = EntitiesContext.POTypes.Where(x => x.IsActive == pIsActive).ToList();
                else
                    POTypeList = EntitiesContext.POTypes.ToList();

                if (POTypeList != null && POTypeList.Count > 0)
                {
                    res.POTypeCollection = new List<POTypeBo>();
                    foreach (var POType in POTypeList)
                    {
                        POTypeBo POTypeBo = new POTypeBo();
                        POTypeBo.ID = POType.ID;
                        POTypeBo.POTypeCode = POType.POTypeCode;
                        POTypeBo.POTypeName = POType.POTypeName;
                        POTypeBo.LeadDays = POType.LeadDays;
                        POTypeBo.Description = POType.Description;
                        POTypeBo.IsActive = POType.IsActive;
                        POTypeBo.CreatedBy = POType.CreatedBy;
                        POTypeBo.CreatedAt = POType.CreatedAt;
                        POTypeBo.UpdatedBy = POType.UpdatedBy;
                        POTypeBo.UpdatedAt = POType.UpdatedAt;
                        POTypeBo.UpdatedCount = POType.UpdatedCount;
                        POTypeBo.Notes = POType.Notes;
                        res.POTypeCollection.Add(POTypeBo);
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
